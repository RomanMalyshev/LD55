using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour {

  [SerializeField] private PlayerInputManager PlayerInputManager;
  [SerializeField] private Transform[] PlayersPosition;
  [SerializeField] private PlayerController PlayerOriginal;

  [SerializeField] private InputActionReference KeyBoardAction_1;


  private void Start() {
    KeyBoardAction_1.action.Enable();

    KeyBoardAction_1.action.started += context => {
      if (PlayerInputManager.playerCount >= PlayerInputManager.maxPlayerCount) return;

      var playerIndex = PlayerInputManager.playerCount + 1;
      var player = Instantiate(PlayerOriginal);
      player.transform.position = new Vector3(
          PlayersPosition[playerIndex].position.x,
          PlayersPosition[playerIndex].position.y,
          PlayerOriginal.transform.position.z);
      Debug.Log("Key 1 connected");
      var playerInput = player.GetComponent<PlayerInput>();
   
      PlayerInputManager.JoinPlayer(playerIndex,-1,null);
      
    };
  }

  [PublicAPI]
  public void OnPlayerJoin(PlayerInput playerInput) {
    Debug.Log("Player Join");

    var playerController = playerInput.GetComponent<PlayerController>();

    playerController.transform.position = new Vector3(
        PlayersPosition[playerInput.playerIndex].position.x,
        PlayersPosition[playerInput.playerIndex].position.y,
        playerController.transform.position.z);

  }

  [PublicAPI]
  public void OnPlayerLeft(PlayerInput playerInput) {
    Debug.Log("Player Left");
  }
}
