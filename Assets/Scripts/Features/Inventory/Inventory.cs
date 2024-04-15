using UnityEngine;

public class Inventory : MonoBehaviour {
  [SerializeField] private MeshRenderer ItemMR;
  [SerializeField] private MeshFilter ItemMF;
  public InteractableObject contain;

  private bool rendered => ItemMF != null && ItemMR != null;

  public bool SetItem(InteractableObject item) {
    if (contain != null) return false;
    if (item == null) return false;

    if (rendered) {
      ItemMR.material.mainTexture = item.GetComponent<MeshRenderer>().material.mainTexture;
      ItemMF.mesh = item.GetComponent<MeshFilter>().mesh;
    }

    contain = item;
    contain.SetInteractable(false);
    contain.gameObject.SetActive(false);
    return true;
  }

  public InteractableObject RemoveItem() {
    var item = contain;
    if (rendered) {
      ItemMF.mesh = null;
    }
    contain = null;
    return item;
  }

  public bool TransferItem(Inventory inventory) {
    if (!inventory.SetItem(contain)) return false;
    RemoveItem();
    return true;
  }

}
