using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Ky;

public class InteractionController : MonoBehaviour {
  private readonly List<IInteractable> _interactable = new();
  [SerializeField] private List<float> dList = new();
  private readonly List<PlayerController> _players = new();
  private readonly Dictionary<PlayerController, GameObject> InteractableItemInfo = new();
  private readonly Dictionary<PlayerController, IInteractable> InteractableItem = new();

  [SerializeField] private GameObject InteractableItemInfoPrototype;
  [SerializeField] private float InteractionRadius;

  [SerializeField] private Transform WorldUIContainer;
  public void Add(IInteractable targt) {
    _interactable.Add(targt);
    dList.Add(100);
  }

  public void registerPlayer(PlayerController controller) {
    _players.Add(controller);
    controller.OnPlayerInteraction += OnPlayerInteraction;
    InteractableItemInfo.Add(controller, Instantiate(InteractableItemInfoPrototype, WorldUIContainer));
    InteractableItem.Add(controller, null);
  }
  private void OnPlayerInteraction(PlayerController playerController) {
    if (InteractableItem.ContainsKey(playerController)) {
      InteractableItem[playerController].Interact(playerController, InteractionType.Use);
    }
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
    for (var i = 0; i < _interactable.Count; i++) {
      var target = _interactable[i];
      if (!target.Interactable) continue;
      var dist = Vector3.Distance(target.Pos, player.transform.position);
      dList[i] = dist;
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
