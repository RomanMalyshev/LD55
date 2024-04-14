using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {
  private readonly List<IInteractable> _interactable = new();



  public void Add(IInteractable targt) {
    _interactable.Add(targt);
  }

  public void upd() {
    foreach (var target in _interactable) {
      if (!target.Interactabe) continue;

      if (Vector3.Distance(target.Pos, Vector3.one) < 1f) { }
    }
  }
}
