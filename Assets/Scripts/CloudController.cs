using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{

    [SerializeField] private float speed = 5f, axisYSpeed = 0.01f, outOfScreen = 27.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offSet = new Vector2(speed * Time.deltaTime, -axisYSpeed * Time.deltaTime);

        this.transform.Translate(offSet);
        
          if (this.transform.position.x > outOfScreen){
            Destroy(this.gameObject);
        }
    }

}
