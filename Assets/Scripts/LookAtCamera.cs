using System;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

  private Transform _cam;

  private void Start() {
    _cam = Camera.main.transform;
  }

  private void Update() {
    transform.LookAt(_cam);
  }
}
