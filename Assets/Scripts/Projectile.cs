using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    private float speed = 1f;

    [SerializeField]
    private int damage = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //handle collision
        if (collision.CompareTag("Attacker"))
        {
            Health health = collision.GetComponent<Health>();
            health.TakeDamage(damage);

            Attacker attacker = collision.GetComponent<Attacker>();
            attacker.TakeHit();

            Destroy(gameObject);
        }
    }
}
