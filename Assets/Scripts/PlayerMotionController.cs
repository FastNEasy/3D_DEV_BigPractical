using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private float jumpHeight = 8f;
    //for mouse tracking
    [SerializeField] private float mouseSensitivity = 5f;
    private float gravity = 20f;
    private bool groundedPlayer;
    private const float PitchLimit = 89;
    private const float RotationSpeed = 100f;
    private float pitch;
    private float yaw;
    CharacterController charController;
    Vector3 moveDirection;
    [HideInInspector]
    public bool canMove = true;
    void Awake(){
        charController = GetComponent<CharacterController>();
    }
    void Start(){

        pitch = transform.root.eulerAngles.x;
        yaw = transform.rotation.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update(){
            groundedPlayer = charController.isGrounded;
            print(groundedPlayer);
            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");
            yaw += Input.GetAxis("Mouse X") * Time.deltaTime * RotationSpeed * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * Time.deltaTime * RotationSpeed * mouseSensitivity;
            if (pitch > PitchLimit) pitch = PitchLimit;
            if (pitch < -PitchLimit) pitch = -PitchLimit;
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? jumpHeight : walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? jumpHeight : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
           
            if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
            {
                moveDirection.y = jumpHeight;
            }else
            {
                moveDirection.y = movementDirectionY;
            }
            if(!groundedPlayer){
                moveDirection.y -= gravity * Time.deltaTime;
            }
            Rotate();
            charController.Move(moveDirection * Time.deltaTime);
        
    }
    private void Rotate(){
       transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
    }
 
}