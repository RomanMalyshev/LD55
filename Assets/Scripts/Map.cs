using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ky;

public class Map {
  private class Pix {
    public static readonly List<Pix> all = new();
    public static readonly Pix None = new(0x000000, 1);
    public static readonly Pix Floor = new(0x333333, 1);
    public static readonly Pix Wall = new(0xffffff, 1);
    public static readonly Pix Exit = new(0xff00ff, 1);

    public Vector4 value;
    public Pix(uint rgb, float a) : this(hexColor(rgb).r, hexColor(rgb).g, hexColor(rgb).b, a) { }
    public Pix(float r, float g, float b, float a) {
      value = new(r, g, b, a);
      all.Add(this);
    }
  }


  public Map(Transform container, string name) {
    this.container = container;
    png = Resources.Load<Texture2D>($"Maps/{name}");
  }

  private readonly Transform container;
  private readonly Texture2D png;

  public void generate() {
    container.DestroyChildren();
    for (var x = 0; x < png.width; x++) {
      for (var y = 0; y < png.height; y++) {
        if (getPix(x, y).isAnyOf(Pix.Floor, Pix.Exit)) createSprite(R.spriteFloor, x + h, y + h, 0, false);
        if (getPix(x, y).isAnyOf(Pix.Wall)) {
          if (getPix(x, y - 1).isNoneOf(Pix.Wall)) createSprite(R.spriteWallF, x + h, y + 0, -h, true);
          createSprite(getPix(x, y + 1).isAnyOf(Pix.Wall) ? R.spriteWallTFull : R.spriteWallTShort, x + h, y + h, -1, false);
        }
      }
    }
  }

  private void createSprite(Sprite sprite, float x, float y, float z, bool front) {
    var sr = GameObject.Instantiate(R.spriteRenderer, new Vector3(x, y, z), Quaternion.Euler(front ? -90 : 0, 0, 0), container);
    sr.sprite = sprite;
  }

  private Pix getPix(int x, int y) {
    if (x < 0 || y < 0 || x >= png.width || y >= png.height) return Pix.None;
    var value = png.GetPixel(x, y).ToVector4();
    var best = Pix.all[0];
    foreach (var pix in Pix.all) {
      if ((value - best.value).sqrMagnitude <= (value - pix.value).sqrMagnitude) continue;
      best = pix;
    }
    return best;
  }
}
