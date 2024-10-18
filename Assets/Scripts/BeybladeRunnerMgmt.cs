using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Beyblade.Main
{
    [RequireComponent(typeof(Beyblade_PowerUpsMgmt))]
    public class BeybladeRunnerMgmt : MonoBehaviour
    {
        /* What will be here
         *
         * RPM
         * velocity of movement
         *
         *
         * Control/run time for no collisions, gives shield boost or speed boost. plan
         * OnCollision triggers onHit event of collided beyblade => chance to get PowerDriver. which triggers on defeated event in the end
         * Above will send the incoming velocity, eventually will also receive an incoming velocity.
         * OnReceiveCritHit => chance to get Disable DisableChance(float chanceFactor);
         *
         *
         * will consider collision with tag walls. will reduce RPM depending on velocity.
         * player controls
         * manage no collision time
         */

        #region Local Variables

        #region General

        private float _currVelocity = 0;

        public float CurrentVelocity
        {
            get { return _currVelocity; }
            set
            {
                if (value >= 0) _currVelocity = value;
            }
        }

        private float _currRPM = 0;

        public float CurrentRPM
        {
            get => _currRPM;
            set
            {
                if (value >= 0) _currRPM = value;
            }
        }

        private float _maxVelocity = 16;

        public float MaxVelocity
        {
            get => _maxVelocity;
            set
            {
                if (value >= 0) _maxVelocity = value;
            }
        }

        private bool _isPlayer;

        #endregion

        #region Gameplay Variables

        private float _collisionFreeTime;
        private bool _isDisabledDebuff;
        private List<PowerUpsBase> _activePowerUps;

        #endregion

        #endregion

        #region Editor Variables

        #endregion

        #region Unity Events

        /// <summary>
        /// Event generally called on collision, receives collision enemy velocity
        /// </summary>
        [HideInInspector] public UnityEvent<float> OnCollide = new();

        /// <summary>
        /// Called through OnCollide event, provides player's velocity and colliding enemy velocity.
        /// </summary>
        [HideInInspector] public UnityEvent<float, float> OnHitCall = new();

        [HideInInspector] public UnityEvent<bool> DisabledDebuffCall = new();

        /// <summary>
        /// Event called from respective power ups. Consider attaching UI events etc.
        /// </summary>
        [HideInInspector] public UnityEvent<PowerUpsBase> PowerActivate = new();

        /// <summary>
        /// Event called from respective power ups. Aid in power ups list management and UI events
        /// </summary>
        [HideInInspector] public UnityEvent<PowerUpsBase> PowerDeactivate = new();

        [HideInInspector] public UnityEvent OnCritHit = new();

        #endregion

        #region Helper Functions

        #endregion

        private void Start()
        {
            // Setup events subscription as required

            DisabledDebuffCall.AddListener((bool active) => _isDisabledDebuff = active);
        }

        private void Update()
        {
            //Player control pending
            // if(!_isDisabledDebuff)
        }

        private void OnCollisionEnter(Collision other)
        {
            // if tag compared with enemy and walls

            OnHitCall?.Invoke(_currVelocity, other.transform.GetComponent<BeybladeRunnerMgmt>().CurrentVelocity);
        }

        [ContextMenu("Collision")]
        private void TempCollision()
        {
            int x = Random.Range(4, 20);
            OnHitCall?.Invoke(x, 4);

            Debug.Log(x.ToString() + " vs 4");
        }
    }
}