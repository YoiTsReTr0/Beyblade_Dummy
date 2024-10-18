using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using DG.Tweening;
using UnityEngine;

namespace Beyblade.Main
{
    public class PowerUp_Disable : PowerUpsBase
    {
        public PowerUp_Disable(BeybladeRunnerMgmt effectedBeyblade)
        {
            _effectedBeyblade = effectedBeyblade;
        }

        private void Start()
        {
            _powerName = "Disabled";
            ActiveDuration = 5.3f;
        }

        protected override void Power()
        {
            Debug.Log("Disabled Active");

            _effectedBeyblade.DisabledDebuffCall?.Invoke(true);

            DOVirtual.DelayedCall(ActiveDuration, Deactivate);
        }

        public override void Deactivate()
        {
            base.Deactivate();

            Debug.Log("Disabled Deactivated");

            _effectedBeyblade.DisabledDebuffCall?.Invoke(false);
        }
    }
}