using System;
using System.Numerics;
using Unity.Mathematics;

[Serializable]
public struct Cell {
  public int X;
  public int Y;
  public MapObject MapObject;
  public TileEnvironment TileEnvironment;

  public Cell(int x, int y, MapObject obj, TileEnvironment tileEnvironment) {
    X = x;
    Y = y;
    MapObject = obj;
    TileEnvironment = tileEnvironment;
  }

  public Cell(int2 pos, MapObject obj, TileEnvironment tileEnvironment) {
    X = pos.x;
    Y = pos.y;
    MapObject = obj;
    TileEnvironment = tileEnvironment;
  }
}
