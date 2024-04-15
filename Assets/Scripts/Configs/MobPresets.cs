using static Ky;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MobPresets", order = 1)]
public class MobPresets : ScriptableObject {
  [SerializeField] public Mesh[] Parts;
}
