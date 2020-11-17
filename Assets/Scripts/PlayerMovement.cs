using Mirror;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rigidbody;

    private bool cursorLocked = true;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        if(!isLocalPlayer) playerCamera.enabled = false;
    }

    //sets the velocity vector
    public void SetVelocity(Vector3 _velocity) {
        velocity = _velocity;
    }

    //sets the rotational vector
    public void SetRotation(Vector3 _rotation) {
        rotation = _rotation;
    }

    //sets the rotational vector
    public void SetCameraRotation(Vector3 _cameraRotation) {
        cameraRotation = _cameraRotation;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.L)) {
            if(cursorLocked) {
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
            }
            cursorLocked = !cursorLocked;
        }
    }

    //Runs every physics update
    void FixedUpdate() {
        if(!isLocalPlayer) return;
        Move();
        Rotate();
    }

    //Move based on velocity
    void Move() {
        if(velocity != Vector3.zero) {
            //moves the rigidbody while checking for physics interactions
            rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        }
    }

    //rotate the player body and camera
    void Rotate() {
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(rotation));
        if(playerCamera != null) playerCamera.transform.Rotate(-cameraRotation);
    }

}
