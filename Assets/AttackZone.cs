using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackZone : MonoBehaviour {
  
  public MobController _targetMob;
  private List<MobController> _mobsInZone = new();

  public void OnTriggerEnter(Collider other) {
    if (other.TryGetComponent(out MobController mobInArea)) {
      _mobsInZone.Add(mobInArea);

      if (_targetMob == null)
        _targetMob = mobInArea;
    }
  }

  public void OnTriggerExit(Collider other) {
    if (other.TryGetComponent(out MobController mobOutArea)) {
      if (_mobsInZone.Contains(mobOutArea)) {
        _mobsInZone.Remove(mobOutArea);
      }

      if (_targetMob == mobOutArea) {
        _targetMob = null;

        if (_mobsInZone.Count > 0)
          _targetMob = _mobsInZone[0];
      }
    }
  }
}
