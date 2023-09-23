using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Interfaces;

namespace _Scripts.Core
{
    public class DamageReciever : CoreComponent, IDamagable
    {
        [SerializeField] private GameObject damageParticles;

        private Stats stats;
        private ParticleManager particleManager;

        public void Damage(float amount)
        {
            stats.Health.Decrease(amount);
            stats.HealthBar.UpdateHealthBar(stats.Health.CurrentValue, stats.Health.MaxValue);
            particleManager.StartParticlesWithRandomRotation(damageParticles);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
            particleManager = core.GetCoreComponent<ParticleManager>();
        }
    }
}
