using System;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

  private Transform _cam;

  private void Start() {
    _cam = Camera.main.transform;
  }

  private void Update() {
    Vector3 direction = -_cam.transform.forward;
    transform.rotation = Quaternion.LookRotation(direction, Vector3.down);
  }
}
