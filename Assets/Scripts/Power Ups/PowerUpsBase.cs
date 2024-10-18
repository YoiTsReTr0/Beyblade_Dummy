using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beyblade.Main
{
    public abstract class PowerUpsBase : MonoBehaviour
    {
        protected string _powerName = "";

        protected BeybladeRunnerMgmt _effectedBeyblade;

        /// <summary>
        /// Duration for the power-up to be active
        /// </summary>
        protected float ActiveDuration;

        /// <summary>
        /// Describes what the power is about
        /// </summary>
        protected abstract void Power();

        /// <summary>
        /// Call this to activate your power
        /// </summary>
        public virtual void Activate()
        {
            _effectedBeyblade.PowerActivate?.Invoke(this);

            Power();
        }

        /// <summary>
        /// Call this to deactivate your power
        /// </summary>
        public virtual void Deactivate()
        {
            _effectedBeyblade.PowerDeactivate?.Invoke(this);
        }
    }
}