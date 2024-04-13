using UnityEngine;
using static Ky;

public class ResourcesHelper : MonoBehaviour {
  private void Awake() {
    R = this;
    gameObject.SetActive(false);
  }

  [SerializeField] public SpriteRenderer floor;
  [SerializeField] public SpriteRenderer wall;
}
