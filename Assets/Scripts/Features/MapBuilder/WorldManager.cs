using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldManager : MonoBehaviour {
  [SerializeField] private TerrainBuilder TerrainBuilder;
  [SerializeField] private PlayersManager PlayersManager;
  [SerializeField] private InteractionController InteractionController;
  [SerializeField] private FollowTarget FollowCamera;
  [SerializeField] private AltarController altarController;

  [SerializeField] private Transform terrainContainer;
  [SerializeField] private Transform environmentContainer;
  [SerializeField] private Transform itemContainer;
  [SerializeField] private Transform playerContainer;
  [SerializeField] private Transform enemyContainer;
  [SerializeField] private Transform buildingsContainer;
  [SerializeField] private Transform worldUIContainer;


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
    PlayersManager.OnPlayerCreated += Follow;
    PlayersManager.OnPlayerCreated += altarController.OnPlayerCreated;
    altarController.Init();
  }
  private void Follow(PlayerController obj) {
    FollowCamera.SetTarget(obj.transform);
  }


  public void Upd() {
    InteractionController.Upd();
  }
  public void Dispose() { }
}
