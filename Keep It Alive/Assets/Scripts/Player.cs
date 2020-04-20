using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool Wpressed;
    public bool Apressed;
    public bool Spressed;
    public bool Dpressed;

    public float Speed;

    public AudioClip[] Footsteps;
    public AudioSource FootstepEmitter;

    int footstepTimer;

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

        Vector2 movement = Vector2.zero;
        
        movement += (vertical * Vector2.up).normalized;
       
        movement += (horizontal * Vector2.right).normalized;
        

        //Move
        rigidbody.velocity = movement * Speed * Time.deltaTime;

        if(movement != Vector2.zero)
        {
            footstepTimer++;

            if(footstepTimer > 10)
            {
                footstepTimer = 0;
                FootstepEmitter.clip = Footsteps[Random.Range(0, Footsteps.Length)];
                FootstepEmitter.Play();
            }
        }


    }
}
