using System;
using UnityEngine;

public class EllenPlayerController : PlayerController, IWeaponObserver<GameObject>
{
    [SerializeField] private Transform weaponAttachTransform;

    private MeleeWeaponController _meleeWeaponController;

    private void Start()
    {
        var staffObject = Resources.Load<GameObject>("Staff");
        _meleeWeaponController = Instantiate(staffObject, weaponAttachTransform).GetComponent<MeleeWeaponController>();
        _meleeWeaponController.Subscribe(this);
    }

    public void MeleeAttackStart()
    {
        _meleeWeaponController.StartTrigger();
    }

    public void MeleeAttackEnd()
    {
        _meleeWeaponController.EndTrigger();
    }
    
    public void OnNext(GameObject value)
    {
        var enemyController = value.GetComponent<EnemyController>();
        
        var attackDirection = (enemyController.transform.position - transform.position).normalized;
        enemyController?.SetHit(10, attackDirection);
        
        Debug.Log("플레이어가 적 공격");
    }

    public void OnCompleted()
    {
        _meleeWeaponController.UnSubscribe(this);
    }

    public void OnError(Exception error)
    {
    }
}
