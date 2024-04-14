using UnityEngine;

public class FollowTarget : MonoBehaviour {

  [SerializeField] private Transform _target;

  public void SetTarget(Transform t) {
    _target = t;
  }

  private void Update() {
    if (_target != null)
      transform.position = _target.position;
  }
}
