using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Beyblade_GameManager : MonoBehaviour
{
    /* What will be here
     *
     * Events Management:
     * OnGameStart
     *
     * OnOneDefeated
     *
     *
     * list of beyblades. and assigning
     */

    public static Beyblade_GameManager instace;

    #region Local Variables

    #endregion

    #region Editor Variables

    #endregion

    #region Unity Events

    [HideInInspector] public UnityEvent OnGameStart = new();
    [HideInInspector] public UnityEvent OnGameOver = new();

    #endregion

    #region Helper Functions

    #endregion

    private void Awake()
    {
        // Instance declaration 
        {
            if (instace == null)
                instace = this;

            else
                Destroy(gameObject);
        }
    }
}