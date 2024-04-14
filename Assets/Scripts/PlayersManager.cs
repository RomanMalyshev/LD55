using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour {

  [SerializeField] private PlayerInputManager PlayerInputManager;
  [SerializeField] private Transform[] PlayersPosition;
  [SerializeField] private PlayerController PlayerOriginal;
  [SerializeField] private PlayerConnectionView PlayerConnectionView;
  [SerializeField] private InputActionReference[] KeyBoardAction;
  [SerializeField] private bool NeedInit;

  private int _realPlayerInGame = -1;
  private readonly List<PlayerController> _players = new();
  private readonly Dictionary<InputActionReference, bool> _isSplitPlayerJoin = new();

  public Action<PlayerController> OnPlayerCreated;

  private void Start() {
    if (NeedInit)
      Init(PlayersPosition);
  }
  public void Init(Transform[] positions) {
    PlayersPosition = positions;
    var actionAsset = KeyBoardAction[0].asset;
    actionAsset.actionMaps.ForEach(it => it.asset.Enable());

    for (int i = 0; i < KeyBoardAction.Length; i++) {
      _isSplitPlayerJoin.Add(KeyBoardAction[i], false);
      KeyBoardAction[i].action.Enable();

      var index = i;

      KeyBoardAction[i].action.started += context => {
        Debug.Log($" {context.action.name}  {_realPlayerInGame}  Create split player " + _isSplitPlayerJoin[KeyBoardAction[index]]);

        if (_realPlayerInGame >= PlayerInputManager.maxPlayerCount) return;
        if (_isSplitPlayerJoin[KeyBoardAction[index]]) return;

        _isSplitPlayerJoin[KeyBoardAction[index]] = true;

        var player = Instantiate(PlayerOriginal);

        player.transform.position = new Vector3(
            PlayersPosition[_realPlayerInGame].position.x,
            PlayersPosition[_realPlayerInGame].position.y,
            PlayerOriginal.transform.position.z);

        var playerInput = player.GetComponent<PlayerInput>();
        playerInput.actions = actionAsset;
        playerInput.defaultActionMap = $"Player_{index + 2}";

        //_realPlayerInGame++;
        _players.Add(player);
      };
    }
  }

  [PublicAPI]
  public void OnPlayerJoin(PlayerInput playerInput) {
    if (_realPlayerInGame >= PlayerInputManager.maxPlayerCount) return;
    Debug.Log("Player Join");

    var playerController = playerInput.GetComponent<PlayerController>();

    playerController.transform.position = new Vector3(
        PlayersPosition[playerInput.playerIndex].position.x,
        playerController.transform.position.y,
        PlayersPosition[playerInput.playerIndex].position.z);
    _players.Add(playerController);
    _realPlayerInGame++;
    OnPlayerCreated?.Invoke(playerController);

    var connectWithKeyboard = false;
    foreach (var device in playerInput.devices) {
      if (device.device == Keyboard.current)
        connectWithKeyboard = true;
    }
    PlayerConnectionView.PlayerConnected(playerInput.playerIndex, connectWithKeyboard);
  }

  public void Reset() {
    _realPlayerInGame = -1;

    foreach (var player in _players)
      Destroy(player.gameObject);

    _players.Clear();
    _isSplitPlayerJoin.Clear();

    for (var i = 0; i < KeyBoardAction.Length; i++) {
      _isSplitPlayerJoin.Add(KeyBoardAction[i], false);
    }
  }

  [PublicAPI]
  public void OnPlayerLeft(PlayerInput playerInput) {
    Debug.Log("Player Left");
    PlayerConnectionView.PlayerDisconnected(playerInput.playerIndex);
  }
}
