using UnityEngine;
using static Ky;

public abstract class InteractableObject : MonoBehaviour, IInteractable {
  private bool _interactable = true;

  public Vector3 Pos => transform.position;
  public bool Interactable => _interactable;

  public void Start() {
    Ic.Add(this);
  }

  public virtual void Interact(PlayerController playerController, InteractionType type) { Debug.Log("Item Picked Up"); }
  public virtual void SetInteractable(bool b) { _interactable = b; }
}
