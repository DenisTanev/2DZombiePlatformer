using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace _Scripts.Core
{
    public class Stats : CoreComponent
    {
        public event Action OnHealthZero;

        [SerializeField] private float maxHealth;
        [SerializeField] FloatingHealthBar healthBar;

        private float currentHealth;

        protected override void Awake()
        {
            base.Awake();

            currentHealth = maxHealth;

            healthBar = GetComponentInChildren<FloatingHealthBar>();
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        public void DecreaseHealth(float amount)
        {
            currentHealth -= amount;
            healthBar.UpdateHealthBar(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                OnHealthZero?.Invoke();
            }
        }

        public void IncreaseHealth(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        }
    }
}
