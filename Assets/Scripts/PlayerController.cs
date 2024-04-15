using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

  [SerializeField] private Rigidbody Rigidbody;
  [SerializeField] private Transform HandLeft;
  [SerializeField] private Transform RightHand;
  [SerializeField] private float _playerSpeed = 2.0f;
  [SerializeField] private float _rotateSpeed = 2.0f;

  [SerializeField] public Inventory Inventory;
  [SerializeField] public AttackZone AttackZone;

  public Action<PlayerController> OnPlayerAttack;
  public Action<PlayerController> OnPlayerInteraction;

  private Vector2 _movementInput = Vector2.zero;

  private void Start() {
    Inventory.RemoveItem();
  }

  [PublicAPI]
  public void PickUpItem(InteractableObject item) {
    Inventory.SetItem(item);
  }

  [PublicAPI]
  public void OnMove(InputAction.CallbackContext context) {
    _movementInput = context.ReadValue<Vector2>();
  }

  [PublicAPI]
  public void OnAttack(InputAction.CallbackContext context) {
    Debug.Log(context.performed ? "Start Attack" : "End Attack");
    if (Inventory.contain != null) {
      var item = Inventory.RemoveItem();
      item.SetInteractable(true);
      item.gameObject.SetActive(true);
      item.transform.position = transform.position;
      return;
    }

    OnPlayerAttack?.Invoke(this);
    HandLeft.localRotation = Quaternion.Euler(context.performed ? 260 : 335, 0, 0);

    if (context.performed && AttackZone._targetMob != null)
      AttackZone._targetMob.Hit();


  }

  [PublicAPI]
  public void OnInteract(InputAction.CallbackContext context) {
    Debug.Log(context.performed ? "Start Interact" : "End Interact");

    RightHand.localRotation = Quaternion.Euler(context.performed ? 260 : 335, 0, 0);

    if (context.performed) {
      OnPlayerInteraction?.Invoke(this);
    }
  }

  private void FixedUpdate() {
    var move = new Vector3(_movementInput.x, 0, _movementInput.y);

    if (move == Vector3.zero) {
      return;
    }
    Quaternion targetRotation = Quaternion.LookRotation(new Vector3(_movementInput.x, 0, _movementInput.y), Vector3.up);
    targetRotation = Quaternion.RotateTowards(
        transform.rotation,
        targetRotation,
        360 * Time.fixedDeltaTime * _rotateSpeed);
    Rigidbody.MovePosition(Rigidbody.position + move * (_playerSpeed * Time.fixedDeltaTime));

    Rigidbody.MoveRotation(targetRotation);
  }
}
