using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;

    public float JumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        // isOnGround check so the player cannot jump multiple times when on air
        // gameOver check so the player cannot jump the game is over
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) 
        {
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);  //player jumps
            isOnGround = false; 
            playerAnimation.SetTrigger("Jump_trig");
        }
    }

     private void OnCollisionEnter(Collision Collision) {
    if(Collision.gameObject.CompareTag("Ground") || Collision.gameObject.CompareTag("Platform")){
        isOnGround = true;
    }
     else if (Collision.gameObject.CompareTag("Obstacle") || Collision.gameObject.CompareTag("Enemy"))  {
        gameOver = true;
        Debug.Log("Game Over!");
        playerAnimation.SetBool("Death_b",true);
        playerAnimation.SetInteger("DeathType_int",1);
     }
     
    }
}
