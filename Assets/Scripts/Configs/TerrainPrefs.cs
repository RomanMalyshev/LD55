using System;
using UnityEngine;

[Serializable]
public class TerrainPrefs : MonoBehaviour {
  [SerializeField] public TerrainElementsScriptableObject Walls;
  [SerializeField] public TerrainElementsScriptableObject Roofs;
  [SerializeField] public GameObject Ground;
  [SerializeField] public GameObject Error;
}
