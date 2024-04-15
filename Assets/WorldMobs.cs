using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class WorldMobs : MonoBehaviour {
  
  [SerializeField] private Transform[] SpawnPoints;
  [SerializeField] private MobController MobSkeleton;
  [SerializeField] private NavMeshAgent NavMeshAgent;

  private List<MobController> _mobs = new();
  private int _maxMobs = 20;
  
  private void Start() {

    StartCoroutine(MobSpawnDelay());
  }

  public void SetMaxMobs(int playerCount) {
    _maxMobs = playerCount * 20;
  }

  private IEnumerator MobSpawnDelay() {
    while (true) {
      RandomSpawn();
      yield return new WaitForSeconds(1f);
      CheckMobsAFK();
    }
  }


  [ContextMenu("test random spawn")]
  public void RandomSpawn() {
    if (_mobs.Count >= _maxMobs) return;
    for (int i = 0; i < 5; i++) {
      var randomCirclePoint = Random.insideUnitCircle * 7;
      var randomPoint = SpawnPoints[Random.Range(0,SpawnPoints.Length)].position +
          new Vector3(randomCirclePoint.x, 0, randomCirclePoint.y);
      NavMeshHit hit;
      if (NavMesh.SamplePosition(randomPoint, out hit, 6, NavMesh.AllAreas)) {
        var mob = Instantiate(MobSkeleton, hit.position, Quaternion.identity, transform);
        mob.OnDeath += OnMobDeath;
        RandomDestination(mob);
        _mobs.Add(mob);
        return;
      }
    }
    Debug.LogWarning("Gave up");
  }
  private void OnMobDeath(MobController mobController) {
    _mobs.Remove(mobController);
    Destroy(mobController.gameObject);
  }


  public void RandomDestination(MobController mob) {
    for (int i = 0; i < 3; i++) {
      var randomCirclePoint = Random.insideUnitCircle * 10;
      var randomPoint = mob.transform.position +
          new Vector3(randomCirclePoint.x, 0, randomCirclePoint.y);
      NavMeshHit hit;
      if (NavMesh.SamplePosition(randomPoint, out hit, 15, NavMesh.AllAreas))
      {
        if (CanMoveTo(hit.position,mob)) {
          mob.SetTarget(hit.position);
          return;
        }
        else
        {
          continue;
        }
      } 
    }
    Debug.LogWarning("Gave up");
  }

  private bool CanMoveTo(Vector3 destination,MobController mob) {
    NavMeshPath path = new NavMeshPath();
    bool hasPath = NavMesh.CalculatePath(mob.transform.position, destination, NavMesh.AllAreas, path);
    if (!hasPath) return false;
    if (path.status != NavMeshPathStatus.PathComplete) return false;

    return true;
  }
  
  private void CheckMobsAFK() {
    foreach (var mob in _mobs) {
      if (mob.IsStop()) 
        RandomDestination(mob);
    }
  }
}
