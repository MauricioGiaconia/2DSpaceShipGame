using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    [SerializeField] private Transform firePoint;
    public GameObject bulletPrefab;

    private float fireRate = 0.5f, nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Shoot();
        }
        
    }

    void Shoot(){
        //Codigo para disparar
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
