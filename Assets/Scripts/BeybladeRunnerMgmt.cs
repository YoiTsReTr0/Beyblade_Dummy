using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Beyblade.Main
{
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
            get { return _currRPM; }
            set
            {
                if (value >= 0) _currRPM = value;
            }
        }

        private float _maxVelocity = 16;

        public float MaxVelocity
        {
            get { return _maxVelocity; }
            set
            {
                if (value >= 0) _maxVelocity = value;
            }
        }

        private bool _isPlayer;

        #endregion

        #region Gameplay Variables

        private float _collisionFreeTime = 0;
        private bool _isDisabledDebuff;
        private CurrentActivePowerUp _activePower;

        #endregion

        #endregion

        #region Editor Variables

        #endregion

        #region Unity Events

        [HideInInspector] public UnityEvent<float> OnHit = new();
        [HideInInspector] public UnityEvent<string> PowerActive = new();

        #endregion

        #region Helper Functions

        #endregion

        private void Start()
        {
            // Setup events subscription as required
        }

        private void Update()
        {
            //Player control pending
            // if(!_isDisabledDebuff)
        }
    }
}