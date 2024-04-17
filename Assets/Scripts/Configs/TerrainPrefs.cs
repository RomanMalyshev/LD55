using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TerrainPrefs : MonoBehaviour {
  [SerializeField] public GameObject[] Walls;
  [SerializeField] public GameObject[] Roofs;
  [SerializeField] public GameObject Ground;
  [SerializeField] public GameObject Error;

  public Dictionary<TileEnvironment, GameObject> TerrainWalls = new();
  public Dictionary<TileEnvironment, GameObject> TerrainRoofs = new();

  public GameObject Get(Dictionary<TileEnvironment, GameObject> array, TileEnvironment environment) {

    if (array.TryGetValue(environment, out var val)) return val;

    var n = "";

    for (int i = 0; i < 9; i++) {
      if (!environment.HasFlag((TileEnvironment) (1 << i))) continue;
      var c = ((TileEnvironment) (1 << i)) switch {
          TileEnvironment.Self => 'S',
          TileEnvironment.Top => 'T',
          TileEnvironment.Right => 'R',
          TileEnvironment.Down => 'D',
          TileEnvironment.Left => 'L',
          TileEnvironment.TopRight => 't',
          TileEnvironment.RightDown => 'r',
          TileEnvironment.DownLeft => 'd',
          TileEnvironment.LeftTop => 'l',
          _ => '*'
      };
      n += c;
    }
    var obj = Instantiate(Error);
    obj.name = (n);
    return obj;
  }

  public void Init() {
    SetArray(Walls, TerrainWalls);
    SetArray(Roofs, TerrainRoofs);
  }

  private void SetArray(GameObject[] Walls, Dictionary<TileEnvironment, GameObject> array) {
    foreach (var element in Walls) {
      var mask = GetMask(element.name);
      if (!array.TryAdd(mask, element)) {
        Debug.LogError($"{element.name} не может быть добавлен", element);
        Debug.Log($"{element.name} конфликтует с {array[mask].name}", array[mask].gameObject);
      }
    }
  }

  private TileEnvironment GetMask(string name) {
    var mask = TileEnvironment.Self;

    for (var c = 1; c < name.Length; c++) {
      mask |= name[c] switch {
          'S' => TileEnvironment.Self,
          'T' => TileEnvironment.Top,
          'R' => TileEnvironment.Right,
          'D' => TileEnvironment.Down,
          'L' => TileEnvironment.Left,
          't' => TileEnvironment.TopRight,
          'r' => TileEnvironment.RightDown,
          'd' => TileEnvironment.DownLeft,
          'l' => TileEnvironment.LeftTop,
          _ => throw new Exception(name)
      };
    }
    return mask;
  }
}
