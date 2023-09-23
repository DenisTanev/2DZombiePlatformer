using _Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class KnockBackData : ComponentData<AttackKnockBack>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(KnockBack);
        }
    }
}
