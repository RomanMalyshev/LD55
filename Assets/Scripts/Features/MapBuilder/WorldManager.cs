using UnityEngine;

public class WorldManager : MonoBehaviour {
  [SerializeField] private TerrainBuilder TerrainBuilder;

  [SerializeField] private Transform unitsContainer;
  [SerializeField] private Transform terrainContainer;
  [SerializeField] private Transform environmentContainer;
  [SerializeField] private Transform entityContainer;

  public Transform UnitsContainer => unitsContainer;
  public Transform TerrainContainer => terrainContainer;
  public Transform EnvironmentContainer => environmentContainer;
  public Transform EntityContainer => entityContainer;

  public void Init() {
    TerrainBuilder.Init(this);
  }
  public void Upd() { }
  public void Dispose() { }
}
