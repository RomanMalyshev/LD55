using UnityEngine;

public class Item : MonoBehaviour, IInteractable {

  [SerializeField] private bool Interactable;
  public Vector3 Pos => transform.position;
  public bool Interactabe => Interactable;

  public void Init(InteractionController controller) {
    controller.Add(this);
  }

  public void Interact(PlayerController playerController, InteractionType type) { Debug.Log("Item Picked Up"); }
}
