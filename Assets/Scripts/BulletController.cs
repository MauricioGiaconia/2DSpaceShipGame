using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;

    [SerializeField] private float flameMovement = 15f;
    [SerializeField] private bool isEnemyBullet = false;
    [SerializeField] private GameObject impactEffect;
    private float maxScale = 3f, minScale = 2f, scaleRate = 0.3f, nextScale = 0f, outScreen = 14f;
    private bool reset = false;
    
    public int dmg = 20, dmgToPlayer = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * speed;

        if (isEnemyBullet){
            outScreen = -outScreen;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 actualScale = this.transform.localScale;

        
        
        
        if ((actualScale.x < maxScale && actualScale.y < maxScale) && !reset && Time.time > nextScale){

            nextScale = Time.time + scaleRate;
            this.transform.localScale = new Vector3(flameMovement * Time.deltaTime + actualScale.x, flameMovement * Time.deltaTime + actualScale.y, 0);
            
            if(actualScale.x >= maxScale && actualScale.y >= maxScale){
                reset = true;
            }

        } else{

            this.transform.localScale = new Vector3(-flameMovement * Time.deltaTime - actualScale.x, -flameMovement * Time.deltaTime - actualScale.y, 0);

            if(actualScale.x <= minScale && actualScale.y <= minScale){
                reset = false;
            }
        }

        if ((this.transform.position.y > outScreen && !isEnemyBullet) || (this.transform.position.y < outScreen && isEnemyBullet)){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Player player = hitInfo.GetComponent<Player>();

        
        if (enemy != null){
            enemy.takeDamage(dmg);
        } else if (player != null){
           
            player.takeDamage(dmgToPlayer);
        }

        Instantiate(impactEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
