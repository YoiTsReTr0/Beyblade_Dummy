using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beyblade.Main
{
    public interface IPowerUps
    {

        /// <summary>
        /// Duration for the power-up to be active
        /// </summary>
        float ActiveDuration { get; set; }

        /// <summary>
        /// Describes what the power is about
        /// </summary>
        void Power();

        /// <summary>
        /// Call this to activate your power
        /// </summary>
        void Activate(BeybladeRunnerMgmt beyblade);

        /// <summary>
        /// Call this to deactivate your power
        /// </summary>
        void Deactivate();
    }
}