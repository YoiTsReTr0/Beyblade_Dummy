using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Beyblade.Main
{
    [RequireComponent(typeof(BeybladeRunnerMgmt))]
    [SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
    public class Beyblade_PowerUpsMgmt : MonoBehaviour
    {
        private BeybladeRunnerMgmt _playerBeyblade;

        /// <summary>
        /// Max velocity of either, after which it is a 100% chance for disable
        /// </summary>
        private float _maxProbVelCap = 20;

        /// <summary>
        /// Miv velocity of either, after which there is some chance for disable
        /// </summary>
        private float _minProbVelCap = 0;

        private float _noCollTimer = 11;

        private Tween _delayedCollTimerResetTween;

        #region Helper Functions

        double ProbabilityCalculator(float firstVal, float secondVal)
        {
            float factor = 0;

            factor = firstVal - secondVal;

            return (factor) / (_maxProbVelCap - _minProbVelCap);
        }

        #endregion

        private void Start()
        {
            _playerBeyblade = GetComponent<BeybladeRunnerMgmt>();

            _playerBeyblade.OnHitCall.AddListener((float playerVel, float enemyVel) =>
            {
                OnHitChecks(playerVel, enemyVel);

                // Handle Shield power timer
                _noCollTimer = 11;

                _delayedCollTimerResetTween = DOVirtual.DelayedCall(3, () => { _noCollTimer = 10; });
            });
        }

        private void Update()
        {
            if (_noCollTimer <= 10)
            {
                _noCollTimer -= Time.deltaTime;

                if (_noCollTimer <= 0)
                {
                    _noCollTimer = 11;
                }
            }
        }

        private void OnHitChecks(float playerVel, float enemyVel)
        {
            // chance for Power driver on crit hit same func followup

            if (playerVel < enemyVel)
                CheckForDisableDebuff(playerVel, enemyVel);

            else if (playerVel >= enemyVel)
                CheckForCritHitAndPowerDriver(playerVel, enemyVel);
        }

        private void CheckForDisableDebuff(float playerVel, float enemyVel)
        {
            // Probability setup for disable change

            double probability = ProbabilityCalculator(enemyVel, playerVel);

            double ran = Random.value;

            Debug.Log($"{ran}   {probability}");

            if (ran > probability)
                return;

            PowerUp_Disable power = new(_playerBeyblade);
            power.Activate();
        }

        private void CheckForCritHitAndPowerDriver(float playerVel, float enemyVel)
        {
            if (playerVel > enemyVel * 2)
            {
                Debug.Log("Crit");
                _playerBeyblade.OnCritHit?.Invoke();

                double probability = ProbabilityCalculator(playerVel, enemyVel);

                double ran = Random.value;

                Debug.Log($"{ran}   {probability}");

                if (ran > probability)
                    return;

                // values are to be put for this, depending on player level, power level etc as already discussed
                PowerUp_PowerDriver power = new(_playerBeyblade);
                
                power.Activate();
            }
        }

        private void DefensiveShieldActive()
        {
            
        }
    }
}