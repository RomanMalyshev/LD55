using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class AltarController : MonoBehaviour {
  [SerializeField] private AltarTile[] tiles;
  [SerializeField] private Animator effector;

  private bool _active = false;
  private static readonly int Requested = Animator.StringToHash("Requested");

  public void Init() {
    foreach (var tile in tiles) { tile.SetInteractable(true); }
  }

  private IEnumerator afterStart() {
    yield return new WaitForSeconds(1f);
    SetRequest();
  }

  public void SetRequest() {
    var r = new Random();
    foreach (var tile in tiles) {
      var part = ((BodyPart[]) Enum.GetValues(typeof(BodyPart))).Random(r);
      var monster = ((MonsterType[]) Enum.GetValues(typeof(MonsterType))).Random(r);
      if (r.Next(0, 2) == 1) { tile.SetTileRequest(part, monster); }
    }

    effector.SetTrigger(Requested);
  }

  public void OnPlayerCreated(PlayerController obj) {
    if (_active) return;
    StartCoroutine(afterStart());
    _active = true;
  }

  public void ChekRequest() {
    bool b = true;
    foreach (var tile in tiles) {
      b &= tile.IsItemRequested();
    }
    if (!b) return;
    SetRequest();
  }
}
