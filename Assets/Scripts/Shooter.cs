using System;
using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;

    [Header("AI")]
    [SerializeField] float fireRateVariance = 0.2f;
    [SerializeField] float minimumFireRate = 2f;
    [SerializeField] bool usingAI;

    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;

    private void Start() {
        if(usingAI)
        {
            isFiring = true;
        }
    }

    private void Update() {
        Fire();
    }

    private void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if(!isFiring && firingCoroutine !=null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator FireContinously()
    {
        while(true)
        {
            GameObject instace = Instantiate(projectilePrefab,
                                            transform.position,
                                            Quaternion.identity);
            Rigidbody2D rb = instace.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instace, projectileLifetime);    
            if(usingAI)
            {
                yield return new WaitForSeconds(GetRandomFireRate());
            }
            else  
            {
                yield return new WaitForSeconds(fireRate);
            }                                    
            
        }
        
    }

        public float GetRandomFireRate(){
        float spawnTime = UnityEngine.Random.Range(fireRate - fireRateVariance,
                                        fireRate + fireRateVariance);
        return Mathf.Clamp(spawnTime, minimumFireRate,float.MaxValue);                                        
    }
}
