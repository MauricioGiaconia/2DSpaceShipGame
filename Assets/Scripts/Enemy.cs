using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 1;

    [SerializeField] private GameObject deathEffect;
    
    public void takeDamage(int dmg){

        health -= dmg;

        if (health <= 0){
            Die();
        }
    }

    void Die(){

        Instantiate(deathEffect, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
        DestroyImmediate(deathEffect, true);
    }
    
}
