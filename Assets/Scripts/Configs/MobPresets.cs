using System;
using System.Collections.Generic;
using UnityEngine;

public class MobPresets : MonoBehaviour {
  [SerializeField] private KVContainer<MonsterType, Texture2D>[] _monsters;
  [SerializeField] private KVContainer<BodyPart, Mesh>[] _parts;

  public Dictionary<MonsterType, Texture2D> Textures;
  public Dictionary<BodyPart, Mesh> Meshes;


  public void Awake() {
    foreach (var monster in _monsters) {
      Textures.Add(monster.Key, monster.Value);
    }
    foreach (var mesh in _parts) {
      Meshes.Add(mesh.Key, mesh.Value);
    }
  }
}
