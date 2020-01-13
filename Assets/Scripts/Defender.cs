using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform projectileSpawnPoint;

    private Animator animator;

    [SerializeField, Range(0f, 5f)]
    private float shootSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(ShootProjectiles());
    }

    IEnumerator ShootProjectiles()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootSpeed);

            animator.SetTrigger("shoot");
        }
    }

    public void OnShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
    }
}
