using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFlameEffect : MonoBehaviour
{

    [SerializeField] private float flameMovement = 15f;
    private float maxScale = 1.3f, minScale = 1.0f;
    private bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 actualScale = this.transform.localScale;
 
        if ((actualScale.x < maxScale && actualScale.y < maxScale) && !reset){

            this.transform.localScale = new Vector3(flameMovement * Time.deltaTime + actualScale.x, flameMovement * Time.deltaTime + actualScale.y, 0);
            
            if(actualScale.x >= maxScale && actualScale.y >= maxScale){
                reset = true;
            }

        } else{

            this.transform.localScale = new Vector3(-flameMovement * Time.deltaTime + actualScale.x, -flameMovement * Time.deltaTime + actualScale.y, 0);

            if(actualScale.x <= minScale && actualScale.y <= minScale){
                reset = false;
            }
        }
    }
}
