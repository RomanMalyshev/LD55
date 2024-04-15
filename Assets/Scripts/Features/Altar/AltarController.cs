using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class AltarController : MonoBehaviour {
  [SerializeField] public AltarTile[] tiles;
  [SerializeField] public Animator effector;
  public void Init() {

    StartCoroutine(afterStart());
  }

  public void SetRequest() {
    var r = new Random();
    foreach (var tile in tiles) {
      var part = ((BodyPart[]) Enum.GetValues(typeof(BodyPart))).Random(r);
      var monster = ((MonsterType[]) Enum.GetValues(typeof(MonsterType))).Random(r);
      if (r.Next(0, 2) == 1) { tile.SetTileRequest(part, monster); }
      tile.SetInteractable(true);
      effector.SetTrigger(0);
    }
  }

  public IEnumerator afterStart() {
    yield return new WaitForSeconds(1f);
    SetRequest();
  }
}
