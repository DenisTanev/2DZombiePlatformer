using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class DamageData : ComponentData<AttackDamage>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Damage);
        }
    }
}
