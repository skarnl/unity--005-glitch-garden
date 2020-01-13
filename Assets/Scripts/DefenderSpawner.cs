using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : Singleton
{
    [SerializeField]
    private GameObject defenderToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var viewportPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (viewportPosition.x > 0.5f && viewportPosition.x < 9.5f && viewportPosition.y > 0.5f && viewportPosition.y < 5.5f) {
                Instantiate(defenderToSpawn, new Vector2(Mathf.RoundToInt(viewportPosition.x), Mathf.RoundToInt(viewportPosition.y)), Quaternion.identity);
            }
        }   
    }

    public void SetSelectedPrefab (GameObject defenderPrefab) {
        defenderToSpawn = defenderPrefab;
    }
}
