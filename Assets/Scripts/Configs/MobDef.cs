using static Ky;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MobDef", order = 1)]
public class MobDef : ScriptableObject {
  [SerializeField] public TerrainElementContainer[] Elements;

  private Dictionary<TileEnvironment, GameObject> TerrainElements = new();
  public GameObject Get(TileEnvironment environment) {

    if (TerrainElements.TryGetValue(environment, out var val)) return val;

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
    var obj = Instantiate(R.TerrainPrefs.Error);
    obj.name = (n);
    return obj;
  }


  public void Init() {
    foreach (var element in Elements) {
      var mask = element.Elements;
      if (!TerrainElements.TryAdd(mask, element.Prefab)) {
        Debug.Log(element.Prefab.name, element.Prefab);
        var bug = TerrainElements[mask];
        Debug.Log(bug.name, bug.gameObject);
      }
    }
  }
}
