using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBounds : MonoBehaviour
{
    void Update()
    {
        if (   transform.position.x < -1
            || transform.position.x > 11.5f
            || transform.position.y > 6f
            || transform.position.y < -0.5f
           )
        {
            Destroy(gameObject);
        }
    }
}
