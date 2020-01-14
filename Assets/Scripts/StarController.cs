using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarController : Singleton
{
    [SerializeField]
    private int starBalance = 0;

    private int selectedDefenderCost;

    public TextMeshProUGUI starsText;

    private void Update ()
    {
        starsText.text = "Stars: " + starBalance;
    }

    public int GetStarCount ()
    {
        return starBalance;
    }

    public void AddStars (int starsToAdd)
    {
        starBalance += starsToAdd;
    }

    public bool PayIfHasEnoughStars ()
    {
        if (starBalance - selectedDefenderCost >= 0) {
            starBalance -= selectedDefenderCost;
            return true;
        }

        return false;
    }

    public void SetSelectedDefenderCost (int selectedDefenderCost)
    {
        this.selectedDefenderCost = selectedDefenderCost;
    }
}
