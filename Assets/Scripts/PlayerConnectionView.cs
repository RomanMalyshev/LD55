using UnityEngine;
using UnityEngine.UI;

public class PlayerConnectionView : MonoBehaviour {
  
  [SerializeField] private PlayerStartCard[] Players;
  [SerializeField] private Button StartButton;
  private PlayerStartCard PlayerWithKeyboard;
  private void Start() {
    StartButton.gameObject.SetActive(false);
    StartButton.onClick.AddListener(() => gameObject.SetActive(false));
    Players.ForEach(it => {
      it.SetState(false);
      it.SetKeyBoardState(true);
    });
  }

  public void PlayerConnected(int playerIndex,bool withKeyboard) {
    if (playerIndex >=  Players.Length) {
      Debug.LogWarning("More then max players!");
      return;
    }

    Players[playerIndex].SetState(true);
    PlayerWithKeyboard = Players[playerIndex];
    Players.ForEach(it => { it.SetKeyBoardState(false); });
    
    StartButton.gameObject.SetActive(playerIndex >= 0);
  }
  
  public void PlayerDisconnected(int playerIndex) {
    if (playerIndex >=  Players.Length) {
      Debug.LogWarning("More then max players!");
      return;
    }

    Players[playerIndex].SetState(false);

    if (PlayerWithKeyboard != null && PlayerWithKeyboard == Players[playerIndex]) 
      Players.ForEach(it => { it.SetKeyBoardState(true); });
    
      
    StartButton.gameObject.SetActive(playerIndex >= 0);
  }
}
