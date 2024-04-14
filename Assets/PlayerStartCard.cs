using UnityEngine;
using UnityEngine.UI;

public class PlayerStartCard : MonoBehaviour {

  [SerializeField] private Image EyesIcon;
  [SerializeField] private GameObject ControlRoot;
  [SerializeField] private GameObject JoinedRoot;
  [SerializeField] private GameObject KeyBoardTip;
  [SerializeField] private GameObject GamePadIcon;

  private const float GAMEPAD_BLINK_DELAY = 0.35f;
  private  float _time = 0;
  
  public void SetState(bool playerConnect) {
    ControlRoot.SetActive(!playerConnect);
    JoinedRoot.SetActive(playerConnect);
    EyesIcon.color = playerConnect ? Color.green : Color.red;
  }

  public void SetKeyBoardState(bool keyboardAvailable) {
    KeyBoardTip.SetActive(keyboardAvailable);
  }

  private void Update() {
    _time += Time.deltaTime;
    
    if (_time >= GAMEPAD_BLINK_DELAY) {
      GamePadIcon.SetActive(!GamePadIcon.activeSelf);
      _time = 0f;
    }
  }
}
