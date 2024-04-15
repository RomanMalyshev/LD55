using UnityEngine;

public interface IInteractable {
  Vector3 Pos { get; }
  bool Interactable { get; }

  void Interact(PlayerController playerController, InteractionType type);

}

public enum InteractionType {
  Use,
  Attack,
}
