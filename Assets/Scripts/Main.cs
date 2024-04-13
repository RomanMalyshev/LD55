using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class Main : MonoBehaviour {

  [SerializeField] private Camera camera;
  [SerializeField] private Transform mapContainer;

  private Map? map = null;

  void Start() {
    map = new Map(mapContainer, "azaza");
    map.generate();

  }
  void Update() {
    camera.transform.localPosition = new Vector3(25, 25, 0);
    // camera.orthographicSize = 15f;
  }
}
