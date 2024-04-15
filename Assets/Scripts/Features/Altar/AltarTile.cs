using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarTile : InteractableObject {
  private BodyPartItem contain;
  [SerializeField] private MeshRenderer ItemRequest;
  private Transform Container;

  public void SetTileRequest(BodyPart part, MonsterType monster) {
    //ItemRequest.material.mainTexture = ;
  }
  public void SetItem(BodyPartItem item) { }
  public void GetItem(CharacterController controller) {
    //controller.
  }
  public bool IsItemRequested(BodyPart part, MonsterType monster) {
    return contain.Monster == monster && contain.Part == part;
  }
}
