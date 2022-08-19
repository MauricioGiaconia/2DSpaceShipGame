using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private Transform firePointOriginal, firePointTwo;
    [SerializeField] private GameObject bulletPrefab;

    public bool originalIsShooting = true;

    [SerializeField] private float fireRate = 0.75f;
    private float nextFire = 0f, yPositionToStartShoot = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.y < yPositionToStartShoot){
            if (Time.time > nextFire){
                nextFire = Time.time + fireRate;
                Shoot();
            }
        }
    }

    void Shoot(){

        if (originalIsShooting){

            Instantiate(bulletPrefab, firePointOriginal.position, firePointOriginal.rotation);
            originalIsShooting = false;

        } else {

            Instantiate(bulletPrefab, firePointTwo.position, firePointTwo.rotation);
            originalIsShooting = true;

        }
        
    }
}
