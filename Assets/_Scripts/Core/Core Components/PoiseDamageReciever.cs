using _Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Core
{
    public class PoiseDamageReciever : CoreComponent, IPoiseDamagable
    {
        private Stats stats;

        public void DamagePoise(float amount)
        {
            stats.Poise.Decrease(amount);
            stats.HealthBar.UpdateHealthBar(stats.Health.CurrentValue, stats.Health.MaxValue);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
        }
    }
}
