using _Scripts.Weapons.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class MovementData : ComponentData<AttackMovement>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Movement);
        }
    }
}
