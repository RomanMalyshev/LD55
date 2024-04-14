using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {
  private readonly List<IInteractable> _interactable = new();
  private readonly List<PlayerController> _players = new();
  private readonly Dictionary<PlayerController, GameObject> InteractableItemInfo = new();
  private readonly Dictionary<PlayerController, IInteractable> InteractableItem = new();

  [SerializeField] private GameObject InteractableItemInfoPrototype;
  public void Add(IInteractable targt) {
    _interactable.Add(targt);
  }

  public void registerPlayer(PlayerController controller) {
    _players.Add(controller);
    InteractableItemInfo.Add(controller, Instantiate(InteractableItemInfoPrototype));
  }

  public void Init(PlayersManager manager) {
    manager.OnPlayerCreated += registerPlayer;
  }

  public void Upd() {
    foreach (var player in _players) {
      float max = float.MaxValue;
      foreach (var target in _interactable) {
        if (!target.Interactabe) continue;
        float dist = Vector3.Distance(target.Pos, player.transform.position);
        if (dist < 1f && dist < max) max = dist;
      }
    }
  }
}
