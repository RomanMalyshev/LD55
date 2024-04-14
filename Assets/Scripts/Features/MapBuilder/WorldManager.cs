using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldManager : MonoBehaviour {
  [SerializeField] private TerrainBuilder TerrainBuilder;
  [SerializeField] private PlayersManager PlayersManager;
  [SerializeField] private InteractionController InteractionController;

  [SerializeField] private Transform terrainContainer;
  [SerializeField] private Transform environmentContainer;
  [SerializeField] private Transform itemContainer;
  [SerializeField] private Transform playerContainer;
  [SerializeField] private Transform enemyContainer;
  [SerializeField] private Transform buildingsContainer;


  public List<Transform> positions;



  public Transform TerrainContainer => terrainContainer;
  public Transform EnvironmentContainer => environmentContainer;
  public Transform PlayerContainer => playerContainer;
  public Transform EnemyContainer => enemyContainer;
  public Transform BuildingsContainer => buildingsContainer;
  public Transform ItemContainer => itemContainer;

  public void Init() {
    TerrainBuilder.Init(this);
    PlayersManager.Init(positions.ToArray());
    InteractionController.Init(PlayersManager);
  }


  public void Upd() {
    InteractionController.Upd();
  }
  public void Dispose() { }
}
