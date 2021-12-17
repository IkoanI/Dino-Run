using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    
    private float speed = 20.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    
    public Animator animator;
    
    private float knockbackForce = -5f;
    private float knockbackTime = 1f;
    private float knockbackCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;
        
        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        if(knockbackCounter <= 0)
        {
        moveVector.x = Input.GetAxisRaw("Horizontal") * 7;
        if(Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x > Screen.width/2)
            {
                moveVector.x = 7;
            }
            else
            {
                moveVector.x = -7;
            }
        }
        moveVector.z = speed;
        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime);
        }
        else
        {
            moveVector.z = knockbackForce;
            controller.Move(moveVector * Time.deltaTime);
            knockbackCounter -= Time.deltaTime;
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.point.z > transform.position.z + controller.radius && hit.gameObject.name == "palmtree")
        {
            animator.SetTrigger("hit");
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreCounter>().loseScore();
            Knockback();
        }
    }

    public void Knockback()
    {
        knockbackCounter = knockbackTime;
    }

    public void IncreaseSpeed()
    {
        speed += 10.0f;
    }
}
