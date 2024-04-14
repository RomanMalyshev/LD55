using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static MathHelper;

public class MapProvider : IEnumerable<Cell> {
  public int Size => png.width * png.height;

  private readonly Texture2D png;

  public MapProvider(string name) {
    png = Resources.Load<Texture2D>($"Maps/{name}");
  }
  public IEnumerator<Cell> GetEnumerator() {
    return EnumerateCells().GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() {
    return EnumerateCells().GetEnumerator();
  }

  private IEnumerable<Cell> EnumerateCells() {
    for (var x = 0; x < png.width; x++) {
      for (var y = 0; y < png.height; y++) {
        yield return getCell(new int2(x, y));
      }
    }
  }

  private Cell getCell(int2 pos) {
    var tile = getMapObject(pos.x, pos.y);
    TileEnvironment env = TileEnvironment.Self;
    for (int side = 0; side < 8; side += 2) {
      env |= setCellEnvironment(tile, pos, side);
    }
    return new Cell(pos, tile, env);
  }

  private TileEnvironment setCellEnvironment(MapObject tile, int2 pos, int side) {
    if (side > 8) side = 0;
    if (side < 0) side = 7;

    TileEnvironment ret = 0;
    var rel = GetRel(pos, side);

    if (tile == rel) ret |= (TileEnvironment) (1 << side);

    return ret;
  }

  private MapObject GetRel(int2 pos, int side) {
    var coords = Rel(side) + pos;

    if (!coords.IsInRect(new int4(0, 0, png.width, png.height))) return MapObject.None;

    var obj = getMapObject(coords.x, coords.y);

    return obj;
  }

  private MapObject getMapObject(int x, int y) {
    if (x < 0 || y < 0 || x >= png.width || y >= png.height) return MapObject.None;

    var value = png.GetPixel(x, y).ToVector4();
    var best = MapObject.all[0];

    foreach (var pix in MapObject.all) {
      if ((value - best.value).sqrMagnitude <= (value - pix.value).sqrMagnitude) continue;
      best = pix;
    }

    return best;
  }
}
