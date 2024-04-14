using UnityEngine;

public interface IInteractable {
  Vector3 Pos { get; }
  bool Interactabe { get; }

  void Interact(PlayerController playerController, InteractionType type);
}

public enum InteractionType {
  Use,
  Attack,
}
