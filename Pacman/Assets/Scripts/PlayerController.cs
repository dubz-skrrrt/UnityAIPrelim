using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MovementSpeed = 0f;

    private Vector3 up = Vector3.zero,
                    right = new Vector3(0,90,0),
                    down = new Vector3(0,180,0),
                    left = new Vector3(0,270,0),
                    currentDirection = Vector3.zero;

    private Vector3 initialPos = Vector3.zero;

    void Start(){
        QualitySettings.vSyncCount = 0;

        initialPos = transform.position;

        Reset();
    }

    void Update(){
        var isMoving = true;

        if (Input.GetKey(KeyCode.W)){
            currentDirection = up;
        }else if (Input.GetKey(KeyCode.D)){
            currentDirection = right;
        }else if (Input.GetKey(KeyCode.S)){
            currentDirection = down;
        }else if (Input.GetKey(KeyCode.A)){
            currentDirection = left;
        }else{
            isMoving = false;
        }

        transform.localEulerAngles = currentDirection;

        if(isMoving){
            transform.Translate(Vector3.forward*MovementSpeed*Time.deltaTime);
        }
    }

    public void Reset(){
        transform.position = initialPos;
        currentDirection = down;
    }
    // private CharacterController controller;
    // private Vector3 playerVelocity;
    // public float playerSpeed = 25f;
    // private float gravityValue = -9.81f;


    // private void Start()
    // {
    //     controller = gameObject.AddComponent<CharacterController>();
    // }

    // void Update()
    // {
    //     if (playerVelocity.y < 0)
    //     {
    //         playerVelocity.y = 0f;
    //     }

    //     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //     controller.Move(move * Time.deltaTime * playerSpeed);

    //     if (move != Vector3.zero)
    //     {
    //         gameObject.transform.forward = move;
    //     }

    //     playerVelocity.y += gravityValue * Time.deltaTime;
    //     controller.Move(playerVelocity * Time.deltaTime);
    // }

}