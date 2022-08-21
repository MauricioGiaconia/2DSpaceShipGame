using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{

    [SerializeField] private float enemySpeed = 4f;

    private Player player;

    [SerializeField] private int dmg = 1;
    private float outOfScreen = -11f;
    Vector2 enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        // Encuentra el primer objecto de tipo player cargado
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement = new Vector2(0f, -(enemySpeed * Time.deltaTime + 0.01f));
        this.transform.Translate(enemyMovement);

        if (this.transform.position.y < outOfScreen){

            Destroy(this.gameObject);

            if (player != null){
    
                player.TakeDamage(dmg);
            
            } 
        }
    }
    
}
