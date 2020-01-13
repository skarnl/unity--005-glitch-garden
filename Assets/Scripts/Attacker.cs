using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    [Range(0f, 5f), SerializeField]
    private float movementSpeed = 1f;

    [SerializeField]
    private GameObject explosion;

    private bool jumpFinished;
    private bool hit;
    private bool died;

    // Update is called once per frame
    void Update () {
        if (!jumpFinished || hit || died) {
            return;
        }

        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
    }

    public void OnJumpFinished () {
        jumpFinished = true;
    }

    public void TakeHit () {
        hit = true;

        GetComponent<Animator>().SetTrigger("hit");
    }

    public void OnHitAnimationFinished () {
        hit = false;
    }

    public void YouDied () {
        died = true;

        GetComponent<Renderer>().enabled = false;
        explosion.GetComponent<ParticleSystem>().Play();
        
        Invoke("DestroyYourself", 2f);
    }

    private void DestroyYourself() {
        Destroy(gameObject);
    }
}
