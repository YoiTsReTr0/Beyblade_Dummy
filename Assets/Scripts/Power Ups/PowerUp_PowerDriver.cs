using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beyblade.Main
{
    public class PowerUp_PowerDriver : MonoBehaviour, IPowerUps
    {
        private string PowerName = "Power Driver";

        private BeybladeRunnerMgmt _effectedBeyblade;

        private Coroutine PowerCountdownCoroutine;

        public float ActiveDuration { get; set; }

        public void Power()
        {
            _effectedBeyblade.PowerActive?.Invoke(PowerName);

            _effectedBeyblade.MaxVelocity += 19;

            PowerCountdownCoroutine = StartCoroutine(PowerActiveCountdown());
        }

        public void Activate(BeybladeRunnerMgmt beyblade)
        {
            _effectedBeyblade = beyblade;

            Power();
        }

        public void Deactivate()
        {
            _effectedBeyblade.MaxVelocity = 16;
        }

        private IEnumerator PowerActiveCountdown()
        {
            yield return new WaitForSeconds(10);
            Deactivate();
        }
    }
}