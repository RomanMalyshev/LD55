using UnityEngine;

public class BodyPartItem : InteractableObject {
  [SerializeField] private BodyPart _part;
  [SerializeField] private MonsterType _monster;
  [SerializeField] private MeshRenderer meshRenderer;
  [SerializeField] private MeshFilter meshFilter;
  public BodyPart Part => _part;
  public MonsterType Monster => _monster;

  public void Init(BodyPart part, MonsterType type) {
    meshRenderer.material.mainTexture = Ky.R.Mobs.Textures[type];
    meshFilter.mesh = Ky.R.Mobs.Meshes[part];
    
  }
}
