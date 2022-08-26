
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] private float speed = 0.15f, 
    timeBetweenCloud = 3f, 
    axisXSpawn = -27f, 
    axisYSpawnEnemy = 14f,
    maxXPositionSpawn = 20.5f,
    timeBetweenBuffs = 25f;
    
    [SerializeField] private GameObject cloud1, cloud2, enemy;
    [SerializeField] private GameObject[] buffsNerfs;

    private float randomFloat, wait = 0f, waitBuff = 0f, timeBetweenEnemy = 2f;
    private int randomInt;

    // Start is called before the first frame update
    void Start()
    {      
        
        //Spawn aleatorio de nubes
        InvokeRepeating("SpawnCloud", 0, timeBetweenCloud);

        //Metodo anterior utilizado para que los enemigos disparen
        //InvokeRepeating("SpawnEnemy", timeStartSpawnEnemy, timeBetweenEnemy);

    }

    // Update is called once per frame
    void Update()
    {

        if (enemy != null){
            timeBetweenEnemy = Random.Range(2, 10);
            if (wait < timeBetweenEnemy){

                wait += Time.deltaTime;

            } else{

                SpawnEnemy();
                wait = 0f;
            }
        }

        if (buffsNerfs != null){
            
            if (waitBuff < timeBetweenBuffs){

                waitBuff += Time.deltaTime;
            } else{
            
                SpawnBuffsAndNerfs();
                waitBuff = 0f;
            }
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

        randomFloat =  Random.Range(-maxXPositionSpawn, maxXPositionSpawn);
        Vector3 spawnEnemy = new Vector3(randomFloat, axisYSpawnEnemy, 0f);

        Instantiate(enemy, spawnEnemy, this.transform.rotation);

    }

    void SpawnBuffsAndNerfs(){

        randomFloat =  Random.Range(-maxXPositionSpawn, maxXPositionSpawn);
        int randomInt = Random.Range(0, buffsNerfs.Length);
        Vector3 spawnBuffNerf = new Vector3(randomFloat, axisYSpawnEnemy, 0f);
       
        Instantiate(buffsNerfs[randomInt], spawnBuffNerf, this.transform.rotation);
    }
}
