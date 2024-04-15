using System.Collections;
using static Ky;
using UnityEngine;

public class ActivatorTile : InteractableObject {

  [SerializeField] private Animator Activator;

  [SerializeField] private AltarController altar;

  public void SetTileRequest(BodyPart part, MonsterType monster) { }

  public override void Interact(PlayerController playerController, InteractionType type) {
    if (type != InteractionType.Use) return;
    StartCoroutine(Iteract());

  }

  public IEnumerator Iteract() {
    altar.ChekRequest();
    SetInteractable(false);
    yield return new WaitForSeconds(2f);
    SetInteractable(true);
  }
}
