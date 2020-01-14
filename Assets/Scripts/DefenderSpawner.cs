using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : Singleton
{
    [SerializeField]
    private GameObject defenderToSpawn;

    private List<Vector2> defenderGridPositions = new List<Vector2>();

    private StarController starController;

    private void Awake ()
    {
        starController = FindObjectOfType<StarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var viewportPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (viewportPosition.x > 0.5f && viewportPosition.x < 9.5f && viewportPosition.y > 0.5f && viewportPosition.y < 5.5f) {

                var clickedPosition = new Vector2(
                    Mathf.RoundToInt(viewportPosition.x),
                    Mathf.RoundToInt(viewportPosition.y)
                );
                

                if (!defenderGridPositions.Contains(clickedPosition) && starController.PayIfHasEnoughStars()) {
                        defenderGridPositions.Add(clickedPosition);
                        
                        Instantiate(defenderToSpawn, clickedPosition, Quaternion.identity);
                    }
                }
        }   
    }

    public void DefenderIsKilledOnPosition(Vector2 killedDefenderPosition)
    {
        //TODO remove the defender from the List
    }

    public void SetSelectedPrefab (GameObject defenderPrefab) {
        defenderToSpawn = defenderPrefab;
    }
}
