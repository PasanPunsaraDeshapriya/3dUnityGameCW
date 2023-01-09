using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;



public class MangerCharacterController : MonoBehaviour
{
    private CharacterController charController;
    private Animator charAnimator;

    private float inputX;
    private float inputZ;
    private Vector3 vectorMove;
    private Vector3 vectorVelocity;
    private float speed;
    private float gravity;

    [SerializeField]
    private Transform cameraTransform;



    void Start()
    {
        speed = 2f;
        gravity = 0.5f;
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        charController = tempPlayer.GetComponent<CharacterController>();
        charAnimator=tempPlayer.GetComponent<Animator>();
        //.transform.GetChild(0)


    }


     void Update()
     {
         inputX = Input.GetAxis("Horizontal");
         inputZ = Input.GetAxis("Vertical");

        if (inputZ==0)
        {
            charAnimator.SetBool("isRunning", false);
        }
        else
        {
            charAnimator.SetBool("isRunning", true);
        }
     }

     private void FixedUpdate()
     {
        if (charController.isGrounded)
        {
            vectorVelocity.y = 0f;
        }
        else
        {
            vectorVelocity.y -= gravity * Time.deltaTime;
        }

        vectorMove = charController.transform.forward * inputZ;

        //vectorMove=Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up)*vectorMove;

        charController.transform.Rotate(Vector3.up * inputX*(200f*Time.deltaTime));

        charController.Move(vectorMove*speed*Time.deltaTime);
        charController.Move(vectorVelocity);
        
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    } 
}

