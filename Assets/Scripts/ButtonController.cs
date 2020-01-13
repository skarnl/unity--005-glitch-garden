using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private List<DefenderButton> buttonsList = new List<DefenderButton>();

    private DefenderSpawner defenderSpawner;

    private void Awake ()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void Start()
	{
        SelectButton(buttonsList[0]);
    }

    public void SetButtonActive (int index) {
        var buttonIndex = 0;

        foreach (var button in buttonsList) {
            button.Deselect();

            if (buttonIndex == index) {
                SelectButton(button);
            }
            
            buttonIndex++;
        }
    }

    private void SelectButton(DefenderButton button)
	{
        button.Select();

        defenderSpawner.SetSelectedPrefab(button.GetPrefab());
    }
}
