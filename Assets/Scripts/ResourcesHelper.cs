using System;
using UnityEngine;
using static Ky;

public class ResourcesHelper : MonoBehaviour {

  [SerializeField] public SpriteRenderer spriteRenderer;
  [SerializeField] public GameObject cubeCollider;

  [Space]
  [SerializeField] public GameObject player;
  [SerializeField] public GameObject skeleton;

  [SerializeField] public TerrainPrefs TerrainPrefs;
  [SerializeField] public MobPresets Mobs;

  public void Init() {
    R = this;
  }
}
