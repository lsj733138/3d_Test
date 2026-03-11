using UnityEngine;
using UnityEngine.AI;

public class AttackEnemyState : EnemyState, ICharacterState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AttackEnemyState(EnemyController enemyController, Animator animator, NavMeshAgent navMeshAgent) 
        : base(enemyController, animator, navMeshAgent) { }


    public void Enter()
    {
        _animator.SetTrigger(EnemyController.EnemyAniParamAttack);
    }

    public void Update()
    {
    }

    public void Exit()
    {
    }
}
