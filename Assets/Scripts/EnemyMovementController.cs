using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{

    [SerializeField] private float enemySpeed = 4f;
    public GameObject _playerShip;

    public GameObject PlayerShip{
        get{
            return _playerShip;
        }

        set{
            _playerShip = value;
        }
    }

    [SerializeField] private int dmg = 1;
    private Player player;
    private float outOfScreen = -11f;
    Vector2 enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement = new Vector2(0f, -(enemySpeed * Time.deltaTime + 0.01f));
        this.transform.Translate(enemyMovement);

        if (this.transform.position.y < outOfScreen){

            Destroy(this.gameObject);

            if (_playerShip != null){
                
                player = _playerShip.GetComponent<Player>();
                player.takeDamage(dmg);
            
            } 
        }
    }
    
}
