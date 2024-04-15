using System;
using UnityEngine;
using Random = System.Random;

public class AltarController : MonoBehaviour {
  [SerializeField] public AltarTile[] tiles;
  [SerializeField] public Animator effector;
  public void Init() {
    SetRequest();
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
}
