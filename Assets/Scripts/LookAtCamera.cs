using System;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

  private Transform _cam;

  [SerializeField] private bool inverse;

  private void Start() {
    _cam = Camera.main.transform;
  }

  private void Update() {
    Vector3 direction = -_cam.transform.forward;
    if (inverse) direction *= -1f;
    transform.rotation = Quaternion.LookRotation(direction, Vector3.down);
  }
}
