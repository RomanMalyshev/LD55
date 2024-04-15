using System.Collections.Generic;
using UnityEngine;
using static MapObject;
using static Ky;

public class TerrainBuilder : MonoBehaviour {
  [SerializeField] private string mapName = "";

  private List<Object> _spawned = new();
  private WorldManager _worldManager;

  private MapProvider Map => new(mapName);
  private ResourcesHelper _resourcesHelper;
  public void Init(WorldManager worldManager, ResourcesHelper resourcesHelper) {
    _worldManager = worldManager;
    _resourcesHelper = resourcesHelper;
    _resourcesHelper.TerrainPrefs.Walls.Init();
    _resourcesHelper.TerrainPrefs.Roofs.Init();
    BuildMap();
  }

  private void BuildMap() {
    var map = Map;
    _spawned.Clear();
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
    Spawn(cell.X, cell.Y, R.TerrainPrefs.Ground, _worldManager.EnvironmentContainer);

    var p = new[] {Player0, Player1, Player2, Player3}.IndexOf(cell.MapObject);
    if (p == -1) return;

    var spawnPoint = new GameObject($"{p}_Spawn");
    spawnPoint.transform.SetParent(_worldManager.PlayerContainer);
    spawnPoint.transform.position = new Vector3(cell.X, 0, cell.Y);
    _worldManager.positions.Add(spawnPoint.transform);
  }

  private void CreateFloor(Cell cell) {
    Spawn(cell.X, cell.Y, R.TerrainPrefs.Ground, _worldManager.EnvironmentContainer);
  }

  private void CreateWall(Cell cell) {
    var wall = Spawn(cell.X, cell.Y, _resourcesHelper.TerrainPrefs.Walls.Get(cell.TileEnvironment), _worldManager.EnvironmentContainer);
    var roof = Spawn(cell.X, cell.Y, _resourcesHelper.TerrainPrefs.Roofs.Get(cell.TileEnvironment), _worldManager.EnvironmentContainer);
    Spawn(cell.X, cell.Y, _resourcesHelper.TerrainPrefs.Ground, _worldManager.EnvironmentContainer);

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


  public void Dispose() {
    if (_spawned == null) return;

    foreach (var go in _spawned) {
      Destroy(go);
    }
  }
}
