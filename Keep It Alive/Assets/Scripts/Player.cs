using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

 
    public float Speed;

    private bool isMovingVertically = false;
    private bool isMovingHorizontally = false;

    public int direction;

    private bool movingright;
    private bool movingup;

    public Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(vertical < 0)
        {

                direction = 0;
                movingup = true;
                movingright = false;

            
        }

        if (horizontal < 0)
        {
            
                direction = 1;
                movingright = true;
                movingup = false;
            

        }

        if (vertical > 0)
        {
            
                direction = 2;
                movingup = true;
                movingright = false;
            

        }

        if (horizontal > 0)
        {
            
                direction = 3;
                movingright = true;
                movingup = false;
            

        }




        Vector2 movement = Vector2.zero;

        if (movingup)
        {
            movement += (vertical * Vector2.up).normalized;
        }
        if (movingright)
        {
            movement += (horizontal * Vector2.right).normalized;
        }
        
       
        

        //Move
        rigidbody.velocity = movement * Speed * Time.deltaTime;


    }
}
