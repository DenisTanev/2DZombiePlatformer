using _Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class PlayerDeath : CoreComponent
    {
        [SerializeField] private GameObject[] deathParticles;

        private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
        private ParticleManager particleManager;

        private Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
        private Stats stats;

        public void Die()
        {
            foreach (var particle in deathParticles)
            {
                ParticleManager.StartParticles(particle);
            }

            core.transform.parent.gameObject.SetActive(false);

            SceneManager.LoadScene(0);
        }

        private void OnEnable()
        {
            Stats.Health.OnCurrentValueZero += Die;
        }

        private void OnDisable()
        {
            Stats.Health.OnCurrentValueZero -= Die;
        }
    }
}
