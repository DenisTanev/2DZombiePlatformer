using System;
using System.Collections;
using System.Collections.Generic;
using OriginalFolderName.Utilities;
using UnityEngine;

namespace _Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        public event Action<bool> OnCurrentInputChange;

        [SerializeField] private float attackCounterResetCooldown;

        public WeaponData_SO Data { get; private set; }

        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set => currentAttackCounter = value >= Data.NumberOfAttacks ? 0 : value; 
        }

        public bool CurrentInput
        {
            get => currentInput;
            set
            {
                if (currentInput != value)
                {
                    currentInput = value;
                    OnCurrentInputChange?.Invoke(currentInput);
                }
            }
        }

        public event Action OnEnter;
        public event Action OnExit;

        private Animator anim;
        public GameObject BaseGameObject { get; private set; }
        public GameObject WeaponSpriteGameObject { get; private set; }
        public AnimationEventHandler EventHandler { get; private set; }
        public Core.Core Core { get; private set; }

        private int currentAttackCounter;

        private Timer attackCounterResetTimer;

        private bool currentInput;

        public void Enter()
        {
            print($"{transform.name} enter");

            attackCounterResetTimer.StopTimer();

            anim.SetBool("active", true);
            anim.SetInteger("counter", CurrentAttackCounter);

            OnEnter?.Invoke();
        }

        public void SetCore(Core.Core core)
        {
            Core = core;
        }

        public void SetData(WeaponData_SO data)
        {
            Data = data;
        }

        private void Exit()
        {
            anim.SetBool("active", false);

            CurrentAttackCounter++;
            attackCounterResetTimer.StartTimer();

            OnExit?.Invoke();
        }

        private void Awake()
        {
            BaseGameObject = transform.Find("Base").gameObject;
            WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;

            anim = BaseGameObject.GetComponent<Animator>();

            EventHandler = BaseGameObject.GetComponent<AnimationEventHandler>();

            attackCounterResetTimer = new Timer(attackCounterResetCooldown);
        }

        private void Update()
        {
            attackCounterResetTimer.Tick();
        }

        private void ResetAttackCounter() => CurrentAttackCounter = 0;

        private void OnEnable()
        {
            EventHandler.OnFinish += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable()
        {
            EventHandler.OnFinish -= Exit;
            attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
        }
    }
}
