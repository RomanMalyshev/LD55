using System;
using UnityEngine;
using UnityEngine.AI;

public class MobController : MonoBehaviour {
  [Header("Settings")]
  [SerializeField] private int Heath;
  [SerializeField] private int Damage;
  [SerializeField] private MonsterType Type;
  [Header("Ref")]
  [SerializeField] private NavMeshAgent NavMeshAgent;
  [SerializeField] private Animator Animator;
  [SerializeField] private Collider EnemyCollider;
  [SerializeField] private BodyPartItem DropItemOriginal;
  
  public Action<MobController> OnDeath;
  public bool _isAttack;
  public PlayerController _targetPlayer;

  private Vector3 _targetPosition;
  private void Start() {
    
  }

  public bool IsStop() {
    return (NavMeshAgent.velocity.magnitude < 0.05f && !_isAttack);
  }

  public void Death() {
    var item = Instantiate(DropItemOriginal,transform.position,Quaternion.Euler(90,0,0));
    item.Init(BodyPart.Head,Type);
       
    Animator.SetBool("isDead", true);
    OnDeath?.Invoke(this);
  }

  public void SetTarget(Vector3 target) {
    NavMeshAgent.SetDestination(target);
  }

  private void Update() {
    if (_isAttack && _targetPlayer != null && _targetPosition != _targetPlayer.transform.position) {
      _targetPosition = _targetPlayer.transform.position;
      NavMeshAgent.SetDestination(_targetPlayer.transform.position);
    }
  }

  public void OnTriggerEnter(Collider other) {
 
    if (other.TryGetComponent<PlayerController>(out PlayerController player)) {
      _isAttack = true;
      _targetPlayer = player;
      _targetPosition = _targetPlayer.transform.position;
      Debug.LogWarning("TargetPlayer");
    }
  }

  public void OnTriggerExit(Collider other) {
    if (other.TryGetComponent<PlayerController>(out PlayerController player)) {
      _isAttack = false;
      _targetPlayer = null;
    }
  }
  
  public void Hit() {
    Heath -= 1;
    if (Heath <= 0)
      Death();
  }
}
