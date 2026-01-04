using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
        //public GameObject obstaclePrefab;
        private Vector3 spawnPos = new Vector3 ( 50, 0 , 18);  //-1.64f);

        private float startDelay = 2;

        private float repeatRate = 5 ;

      
      private PlayerController playerControllerScript ;
      public List<GameObject> spawnObjects;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SpawnObstacle (){
if (playerControllerScript.gameOver == false){
     int index = Random.Range(0, spawnObjects.Count);
     GameObject obstaclePrefab = spawnObjects[index];
     Instantiate(obstaclePrefab,spawnPos,obstaclePrefab.transform.rotation);
    }
           
    }
}
