using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed ; 

    private PlayerController playerControllerScript ; 

    private float leftBound = -80;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false){
            if (gameObject.CompareTag("Enemy"))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed); 
            }else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed); 
            }
        }

         if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle") ){
            Destroy(gameObject);
        }
         if(transform.position.x < leftBound && (gameObject.CompareTag("Enemy") || gameObject.CompareTag("Platform")))
        {
            Destroy(gameObject);
        }
       
    }
}
