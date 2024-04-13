using UnityEngine;
using static Ky;

public class ResourcesHelper : MonoBehaviour {
  private void Awake() {
    R = this;
    gameObject.SetActive(false);
  }

  [SerializeField] public SpriteRenderer spriteRenderer;
  [Space]
  [SerializeField] public Sprite spriteFloor;
  [SerializeField] public Sprite spriteWallF;
  [SerializeField] public Sprite spriteWallTFull;
  [SerializeField] public Sprite spriteWallTShort;
}
