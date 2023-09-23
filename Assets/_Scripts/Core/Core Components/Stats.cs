using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using _Scripts.Core.StatsSystem;

namespace _Scripts.Core
{
    public class Stats : CoreComponent
    {
        [field: SerializeField] public Stat Health { get; private set; }
        [field: SerializeField] public Stat Poise { get; private set; }

        [SerializeField] public FloatingHealthBar HealthBar { get; private set; }

        [SerializeField] private float poiseRecoveryRate;

        private float currentHealth;

        protected override void Awake()
        {
            base.Awake();

            Health.Init();
            Poise.Init();

            HealthBar = GetComponentInChildren<FloatingHealthBar>();
            HealthBar.UpdateHealthBar(Health.CurrentValue, Health.MaxValue);
        }
        private void Update()
        {
            if (Poise.CurrentValue.Equals(Poise.MaxValue))
                return;

            Poise.Increase(poiseRecoveryRate * Time.deltaTime);
        }
    }
}
