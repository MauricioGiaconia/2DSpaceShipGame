using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public float speed = 4.0f;
    private float nextPosition = 0f;
    private Vector2 startPosition;
    private Vector2 moveShip;

    // Start is called before the first frame update
    void Start()
    {
       startPosition = new Vector2(0, -0.01f + (speed+2) * Time.time);
       moveShip = new Vector2(speed * Time.deltaTime + 0.01f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -8f){
            this.transform.Translate(startPosition);
        }
        
        

        if (Input.GetKey(KeyCode.A)){

            nextPosition = this.transform.position.x - moveShip.x;
            if (nextPosition > -17f){
                this.transform.Translate(moveShip);
            }
            
        } else if (Input.GetKey(KeyCode.D)){

            nextPosition = this.transform.position.x + moveShip.x;
            if (nextPosition < 17f){
                this.transform.Translate(-moveShip);
            }

        }
    }
}
