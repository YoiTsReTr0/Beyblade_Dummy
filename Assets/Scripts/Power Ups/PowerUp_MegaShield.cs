using System;
using System.Collections;
using System.Collections.Generic;
using Beyblade.Main;
using UnityEngine;

public class PowerUp_MegaShield : PowerUpsBase
{
    public PowerUp_MegaShield(BeybladeRunnerMgmt effectedBeyblade)
    {
        _effectedBeyblade = effectedBeyblade;
    }

    private void Start()
    {
        _powerName = "Mega Shield";
    }

    protected override void Power()
    {
        // describe functionality

        Deactivate();
    }
}