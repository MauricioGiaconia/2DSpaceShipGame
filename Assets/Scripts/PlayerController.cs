using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 18.0f;

    public float Speed{
        get{return speed;}
        set{speed = value;}
    }
    private float nextPosition = 0f;

    //Posicion final jugable del eje Y para la nave
    [SerializeField] private float playerYPosition = -8.5f, maxXPosition = 20.5f;
    private Vector2 startPosition;
    private Vector2 moveShip;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        startPosition = new Vector2(0, -(speed * Time.deltaTime));
        moveShip = new Vector2(speed * Time.deltaTime + 0.01f, 0);

        if (this.transform.position.y < playerYPosition){
            this.transform.Translate(startPosition);
        }
        
        

        if (Input.GetKey(KeyCode.A)){

            nextPosition = this.transform.position.x - moveShip.x;
            if (nextPosition > -maxXPosition){
                this.transform.Translate(moveShip);
            }
            
        } else if (Input.GetKey(KeyCode.D)){

            nextPosition = this.transform.position.x + moveShip.x;
            if (nextPosition < maxXPosition){
                this.transform.Translate(-moveShip);
            }

        }
    }
}
