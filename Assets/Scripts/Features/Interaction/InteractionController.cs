using System.Collections.Generic;
using UnityEngine;
using static Ky;

public class InteractionController : MonoBehaviour {
  private readonly List<IInteractable> _interactable = new();
  private readonly List<PlayerController> _players = new();
  private readonly Dictionary<PlayerController, GameObject> InteractableItemInfo = new();
  private readonly Dictionary<PlayerController, IInteractable> InteractableItem = new();

  [SerializeField] private GameObject InteractableItemInfoPrototype;
  [SerializeField] private float InteractionRadius;

  [SerializeField] private Transform WorldUIContainer;
  public void Add(IInteractable targt) {
    _interactable.Add(targt);
  }

  public void registerPlayer(PlayerController controller) {
    _players.Add(controller);
    InteractableItemInfo.Add(controller, Instantiate(InteractableItemInfoPrototype, WorldUIContainer));
    InteractableItem.Add(controller, null);
  }

  public void Init(PlayersManager manager) {
    Ic = this;
    manager.OnPlayerCreated += registerPlayer;
  }

  public void Upd() {
    foreach (var player in _players) SetInteractable(player);
  }

  private void SetInteractable(PlayerController player) {
    float max = float.MaxValue;
    IInteractable item = null;
    foreach (var target in _interactable) {
      if (!target.Interactabe) continue;
      var dist = Vector3.Distance(target.Pos, player.transform.position);
      if (dist < max) {
        max = dist;
        item = target;
      }
    }
    if (max <= InteractionRadius) {
      InteractableItem[player] = item;
      InteractableItemInfo[player].transform.position = item.Pos;
      InteractableItemInfo[player].SetActive(true);
    } else {
      InteractableItem[player] = null;
      InteractableItemInfo[player].SetActive(false);
    }
  }


}
