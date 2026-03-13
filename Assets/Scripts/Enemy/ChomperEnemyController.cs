using System;
using UnityEngine;

public class ChomperEnemyController : EnemyController, IWeaponObserver<GameObject>
{
    private MeleeWeaponController _meleeWeaponController;

    private void Start()
    {
        _meleeWeaponController = GetComponent<MeleeWeaponController>();
        _meleeWeaponController.Subscribe(this);
    }

    public void PlayStep()
    {
        
    }

    public void Grunt()
    {
        
    }

    public void AttackBegin()
    {
        _meleeWeaponController.StartTrigger();
    }

    public void AttackEnd()
    {
        _meleeWeaponController.EndTrigger();
    }

    public void OnNext(GameObject value)
    {
        var playerController = value.GetComponent<PlayerController>();
        var knockbackDirection = (playerController.transform.position - transform.position).normalized;
        playerController?.SetHit(10, knockbackDirection);
    }

    public void OnCompleted()
    {
        // 구독 취소
        _meleeWeaponController.UnSubscribe(this);
    }

    public void OnError(Exception error) { }
}
