using Mirror;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : NetworkBehaviour
{
    
    [SerializeField]
    private float speed = 10f;
    private float baseSpeed;
    [SerializeField]
    private float sprintingMultiplier = 2f;
    [SerializeField]
    private float mouseSensitivity = 10f;


    private PlayerMovement movement;

    void Start() {
        movement = GetComponent<PlayerMovement>();
        baseSpeed = speed;
    }

    void Update() {
        if(!isLocalPlayer) return;
        //calculate movment velocity as 3D vector
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        //check for sprinting
        if(Input.GetKey(KeyCode.LeftShift)) {
            speed = baseSpeed * sprintingMultiplier;
        } else {
            speed = baseSpeed;
        }

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;
        //movement vector
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;//normilized causes the result to always be 1 so the actual speed is only dictated by the speed variable

        //send movement to movement script
        movement.SetVelocity(velocity);

        //get horizontal rotation as a 3d vector
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRotation, 0f) * mouseSensitivity;

        //send rotation to movement script
        movement.SetRotation(rotation);

        //get vertical rotation as a 3d vector
        float xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRotation, 0f, 0f) * mouseSensitivity;

        //send camera rotation to movement script
        movement.SetCameraRotation(cameraRotation);
    }

}
