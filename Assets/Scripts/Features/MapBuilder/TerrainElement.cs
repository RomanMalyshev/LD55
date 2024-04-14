using System;
using UnityEngine;

[Serializable]
[Flags]
public enum TileEnvironment : int {
  Self =      0b100000000,
  Top =       0b000000001,
  Right =     0b000000100,
  Down =      0b000010000,
  Left =      0b001000000,
  TopRight =  0b000000010,
  RightDown = 0b000001000,
  DownLeft =  0b000100000,
  LeftTop =   0b010000000
}

[Serializable]
public struct TerrainElementContainer {
  [SerializeField] public TileEnvironment Elements;
  [SerializeField] public GameObject Prefab;
}
