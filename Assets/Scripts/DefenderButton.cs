using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField]
    private GameObject defenderPrefab;

    [SerializeField]
    private int starCost = 30;

    [SerializeField]
    private ButtonController buttonController;

    [SerializeField]
    private int index;

    private bool selected;

    private SpriteRenderer spriteRenderer;

    private void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown ()
    {
        if (!selected) {
            buttonController.SetButtonActive(index);
        }
    }

    public void Select ()
    {
        selected = true;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void Deselect()
	{
        selected = false;
        spriteRenderer.color = new Color(0.388f, 0.388f, 0.388f, 1);
    }

    public GameObject GetPrefab()
    {
        return defenderPrefab;
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
