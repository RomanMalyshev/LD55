using System.Collections.Generic;
using UnityEngine;
using static MapObject;
using static Ky;

public class TerrainBuilder : MonoBehaviour {
  [SerializeField] private string mapName = "";

  private List<Object> _spawned = new();
  private WorldManager _worldManager;

  private MapProvider Map => new(mapName);

  public void Init(WorldManager worldManager) {
    _worldManager = worldManager;
    R.TerrainPrefs.Walls.Init();
    R.TerrainPrefs.Roofs.Init();
    BuildMap();
  }

  private void BuildMap() {
    var map = Map;
    _spawned.Capacity = map.Size;

    foreach (var cell in map) {
      ExecuteBuilder(cell);
    }
  }

  private void ExecuteBuilder(Cell cell) {
    if (cell.MapObject.isAnyOf(None)) return;
    if (cell.MapObject.isAnyOf(Ground, Exit, Player0, Player1, Player2, Player3)) CreateFloor(cell);
    if (cell.MapObject.isAnyOf(Wall)) CreateWall(cell);
    if (cell.MapObject.isAnyOf(Player0, Player1, Player2, Player3)) CreatePlayer(cell);
  }
  private void CreatePlayer(Cell cell) {
    Spawn(cell.X, cell.Y, R.TerrainPrefs.Ground);

    var p = new[] {Player0, Player1, Player2, Player3}.IndexOf(cell.MapObject);
    if (p == -1) return;

    Spawn(cell.X, cell.Y, R.player, _worldManager.UnitsContainer);
  }

  private void CreateFloor(Cell cell) {
    Spawn(cell.X, cell.Y, R.TerrainPrefs.Ground);
  }

  private void CreateWall(Cell cell) {
    var wall = Spawn(cell.X, cell.Y, R.TerrainPrefs.Walls.Get(cell.TileEnvironment));
    var roof = Spawn(cell.X, cell.Y, R.TerrainPrefs.Roofs.Get(cell.TileEnvironment));
    Spawn(cell.X, cell.Y, R.TerrainPrefs.Ground);

    if (!wall.TryGetComponent<MeshRenderer>(out _)) {
      wall.name = $"W_{wall.name}_{cell.X}_{cell.Y}";
    }
    if (!roof.TryGetComponent<MeshRenderer>(out _)) {
      roof.name = $"R_{roof.name}_{cell.X}_{cell.Y}";
    }
  }

  private T Spawn<T>(int x, int y, T resource, Transform container) where T : Object {
    var go = Instantiate<T>(resource, new Vector3(x, 0, y), Quaternion.identity, container);
    _spawned.Add(go);
    return go;
  }

  private T Spawn<T>(int x, int y, T resource) where T : Object {
    var go = Instantiate<T>(resource, new Vector3(x, 0, y), Quaternion.identity, _worldManager.UnitsContainer);
    _spawned.Add(go);
    return go;
  }

  public void Dispose() {
    if (_spawned == null) return;

    foreach (var go in _spawned) {
      Destroy(go);
    }
  }
}
