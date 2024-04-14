using System.Collections.Generic;
using UnityEngine;
using static Ky;

public class MapObject {
  public static readonly List<MapObject> all = new();
  public static readonly MapObject None = new(0x000000, 1);
  public static readonly MapObject Ground = new(0x333333, 1);
  public static readonly MapObject Wall = new(0xffffff, 1);
  public static readonly MapObject Exit = new(0xff00ff, 1);
  public static readonly MapObject Player0 = new(0xff0000, 1);
  public static readonly MapObject Player1 = new(0x00ff00, 1);
  public static readonly MapObject Player2 = new(0x0000ff, 1);
  public static readonly MapObject Player3 = new(0xffff00, 1);

  public Vector4 value;
  public MapObject(uint rgb, float a) : this(hexColor(rgb).r, hexColor(rgb).g, hexColor(rgb).b, a) { }
  public MapObject(float r, float g, float b, float a) {
    value = new(r, g, b, a);
    all.Add(this);
  }
}
