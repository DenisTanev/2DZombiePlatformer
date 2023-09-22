using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Core
{
    public class DamageReciever : CoreComponent, IDamagable
    {
        [SerializeField] private GameObject damageParticles;

        private CoreComp<Stats> stats;
        private CoreComp<ParticleManager> particleManager;

        public void Damage(float amount)
        {
            stats.Comp?.DecreaseHealth(amount);
            particleManager.Comp?.StartParticlesWithRandomRotation(damageParticles);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = new CoreComp<Stats>(core);
            particleManager = new CoreComp<ParticleManager>(core);
        }
    }
}
