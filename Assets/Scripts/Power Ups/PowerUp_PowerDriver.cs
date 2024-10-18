using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Beyblade.Main
{
    public class PowerUp_PowerDriver : PowerUpsBase
    {
        #region Class Variables

        /// <summary>
        /// Basic max velocity. Can also change based on power level, player level etc. Consider setup in constructor
        /// </summary>
        private float _defaultMaxVelocity;

        private float _powerMaxVelocity;

        #endregion

        /// <summary>
        /// Dedicated class constructor
        /// </summary>
        /// <param name="effectedBeyblade">Beyblade Runner class for powers to effect</param>
        /// <param name="defaultMaxVelocity">Adjust values as per Power level or Player level etc</param>
        /// <param name="powerMaxVelocity">Adjust values as per Power level or Player level etc</param>
        public PowerUp_PowerDriver(BeybladeRunnerMgmt effectedBeyblade, float defaultMaxVelocity = 16,
            float powerMaxVelocity = 19)
        {
            _effectedBeyblade = effectedBeyblade;
            _defaultMaxVelocity = defaultMaxVelocity;
            _powerMaxVelocity = powerMaxVelocity;
        }


        private void Start()
        {
            _powerName = "Power Driver";
        }

        protected override void Power()
        {
            Debug.Log("Power Driver Active");

            _effectedBeyblade.MaxVelocity += _powerMaxVelocity;

            DOVirtual.DelayedCall(10, Deactivate);
        }


        public override void Deactivate()
        {
            base.Deactivate();

            Debug.Log("Power Driver Deactivated");

            _effectedBeyblade.MaxVelocity = _defaultMaxVelocity;
        }
    }
}