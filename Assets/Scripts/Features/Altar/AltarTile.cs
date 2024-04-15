using static Ky;
using UnityEngine;

public class AltarTile : InteractableObject {

  [SerializeField] private MeshRenderer RequestItemMR;
  [SerializeField] private MeshFilter RequestItemMF;

  [SerializeField] private Inventory Inventory;

  private BodyPart _part;
  private MonsterType _monster;
  private bool _hasRequest = false;

  public void SetUnrequested() {
    _hasRequest = false;
  }

  public void SetTileRequest(BodyPart part, MonsterType monster) {
    RequestItemMR.material.mainTexture = R.Mobs.Textures[monster];
    RequestItemMF.mesh = R.Mobs.Meshes[part];
    _monster = monster;
    _part = part;
    _hasRequest = true;
  }

  public override void Interact(PlayerController playerController, InteractionType type) {
    if (type != InteractionType.Use) return;
    if (Inventory.contain == null) playerController.Inventory.TransferItem(Inventory);
    else Inventory.TransferItem(playerController.Inventory);
  }


  public bool IsItemRequested() {
    if (!_hasRequest) return true;
    if (Inventory.contain is BodyPartItem p)
      return p.Monster == _monster && p.Part == _part;
    return false;
  }
}
