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

    public void Die(){

        Instantiate(deathEffect, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
       
    }
    
    private void OnCollisionEnter2D(Collision2D other) {


        if (other.gameObject.tag == "item"){
            Debug.Log("Choqué un item!");
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } 
           
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null){
            
            player.TakeDamage(dmgToPlayer);
            Die();
        }
    }
}
