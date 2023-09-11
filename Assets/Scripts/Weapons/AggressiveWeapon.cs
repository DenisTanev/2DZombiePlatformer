using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveWeapon : Weapon
{
    protected SO_AggressiveWeaponData aggressiveWeaponData;

    private List<IDamagable> detectedDamagable = new List<IDamagable>();

    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof(SO_AggressiveWeaponData))
        {
            aggressiveWeaponData = (SO_AggressiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackCounter];

        foreach (IDamagable item in detectedDamagable)
        {
            item.Damage(details.damageAmount);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();

        if (damagable != null)
        {
            detectedDamagable.Add(damagable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();

        if (damagable != null)
        {
            detectedDamagable.Remove(damagable);
        }
    }
}
