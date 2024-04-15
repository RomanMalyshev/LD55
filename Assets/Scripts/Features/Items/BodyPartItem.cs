using UnityEngine;

public class BodyPartItem : InteractableObject {
  [SerializeField] private BodyPart _part;
  [SerializeField] private MonsterType _monster;
  
  public BodyPart Part => _part;
  public MonsterType Monster => _monster;
}
