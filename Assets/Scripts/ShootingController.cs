using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    [SerializeField] private Transform firePointOriginal, firePointTwo;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private AudioSource shootSound; 

    public bool originalIsShooting = true;

    [SerializeField] private float fireRate = 0.75f;

    public float FireRate{
        get{return fireRate;}
        set{fireRate = value;}
    }

    private float nextFire = 0f, yPositionToStartShoot = 10f;

    // Update is called once per frame
    void Update()
    {

        if (isPlayer && Input.GetButton("Fire1") && Time.time > nextFire){

            CalculateFireRate();
        } else if (!isPlayer && this.transform.position.y < yPositionToStartShoot){
            
             if (Time.time > nextFire){
                this.nextFire = Time.time + this.fireRate;
                Shoot();
            }
        }
    }

    void CalculateFireRate(){
        if (Time.time > nextFire){
                this.nextFire = Time.time + this.fireRate;
                Shoot();
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
        
        if (shootSound != null){
            shootSound.Play();
        }
    }
}
