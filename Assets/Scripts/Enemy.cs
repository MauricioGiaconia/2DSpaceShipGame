using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 1;

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float dmgToPlayer = 1;
    
    public void takeDamage(float dmg){

        health -= dmg;

        if (health <= 0){
            Die();
        }
    }

    void Die(){

        Instantiate(deathEffect, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
       
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        
        Player player = hitInfo.GetComponent<Player>();

        if (player != null){
            
            player.TakeDamage(dmgToPlayer);
            Die();
        }
    }
    
}
