using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

 


    public float Speed;

    private bool isMovingVertically = false;
    private bool isMovingHorizontally = false;

    int direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(vertical < 0)
        {
            direction = 0;
            
        }

        if (horizontal < 0)
        {
            direction = 1;
            
        }

        if (vertical > 0)
        {
            direction = 2;
            
        }

        if (horizontal > 0)
        {
            direction = 3;
           
        }




        Vector2 movement = Vector2.zero;

        //put if statements here
        movement += (vertical * Vector2.up).normalized;
        
        //and here
        movement += (horizontal * Vector2.right).normalized;
        
       
        

        //Move
        transform.Translate(movement * Speed * Time.deltaTime);


    }
}
