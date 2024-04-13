using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

  [SerializeField] private CharacterController CharacterController;
  [SerializeField] private Transform HandLeft;
  [SerializeField] private Transform RightHand;

  private Vector3 _playerVelocity;
  private float _playerSpeed = 2.0f;

  private Vector2 _movementInput = Vector2.zero;

  private void Start() { }

  [PublicAPI]
  public void OnMove(InputAction.CallbackContext context) {
    _movementInput = context.ReadValue<Vector2>();
  }

  [PublicAPI]
  public void OnAttack(InputAction.CallbackContext context) {
    Debug.Log("Attack");
    var isAttack = context.ReadValue<bool>();
    HandLeft.rotation = Quaternion.Euler(isAttack ? 260 : 335,0,0);
  }

  [PublicAPI]
  public void OnInteract(InputAction.CallbackContext context) {
    Debug.Log("Interact");
    var isInteract = context.ReadValue<bool>();
    HandLeft.rotation = Quaternion.Euler(isInteract ? 260 : 335,0,0);
  }

  private void Update() {

    var move = new Vector3(_movementInput.x, 0, _movementInput.y);
    CharacterController.Move(move * (Time.deltaTime * _playerSpeed));

    if (move != Vector3.zero) {
      gameObject.transform.forward = move;
    }
  }

}
