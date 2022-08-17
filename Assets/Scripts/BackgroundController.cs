
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] private float speed = 0.5f, 
    timeBetweenCloud = 3f, 
    axisXSpawn = -27f, 
    axisYSpawnEnemy = 14f, 
    timeBetweenEnemy = 1f,
    timeStartSpawnEnemy = 4.5f;
    [SerializeField] private GameObject cloud1, cloud2, enemy;

    private float randomFloat, wait = 0f, aux=0f;
    private int randomInt;

    // Start is called before the first frame update
    void Start()
    {      
        
        InvokeRepeating("SpawnCloud", 0, timeBetweenCloud);

        //InvokeRepeating("SpawnEnemy", timeStartSpawnEnemy, timeBetweenEnemy);

    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenEnemy = Random.Range(2, 10);
        if (wait < timeBetweenCloud){

            wait += Time.deltaTime;

        } else{

            SpawnEnemy();
            wait = 0f;
        }

        Vector2 offset = new Vector2(0, Time.time*speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;


    }

    void SpawnCloud(){

        randomFloat =  Random.Range(-5f, 17f);
        randomInt = Random.Range(1, 3);

        Vector3 spawnCloud = new Vector3(axisXSpawn, randomFloat, 0f);

        if (randomInt == 1){
            Instantiate(cloud1, spawnCloud, this.transform.rotation);
        } else{
            Instantiate(cloud2, spawnCloud, this.transform.rotation);
        }
        
        
    }

    void SpawnEnemy(){
        randomFloat =  Random.Range(-17f, 17f);
        Vector3 spawnEnemy = new Vector3(randomFloat, axisYSpawnEnemy, 0f);

        Instantiate(enemy, spawnEnemy, this.transform.rotation);
    }
}
