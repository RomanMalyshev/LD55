using static Ky;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TerrainElementsScriptableObject", order = 1)]
public class TerrainElementsScriptableObject : ScriptableObject {
  [SerializeField] public TerrainElementContainer[] Elements;

}
