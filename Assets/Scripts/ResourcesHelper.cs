using UnityEngine;
using static Ky;

public class ResourcesHelper : MonoBehaviour {
  private void Awake() {
    R = this;
    gameObject.SetActive(false);
  }

  [SerializeField] public SpriteRenderer spriteRenderer;
  [SerializeField] public GameObject cubeCollider;
  [Space]
  [SerializeField] public Sprite spriteFloor;
  [SerializeField] public Sprite spriteWallF;
  [SerializeField] public Sprite spriteWallTFull;
  [SerializeField] public Sprite spriteWallTShort;
  [Space]
  [SerializeField] public GameObject player;
  [SerializeField] public GameObject skeleton;
}
