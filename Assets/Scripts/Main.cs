using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

  private Map? map = null;

  void Start() {
    map = new Map(transform, "azaza");
    map.generate();
  }
  void Update() { }
}
