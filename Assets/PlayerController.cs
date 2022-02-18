using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    //public InteractableNPC focus;

    public float speed = 6f;

    // for smooth direction snapping of player when dirn is changed with WASD
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        // Set playercontroller to true after a game over
        controller.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // obtain WASD input and store as horizontal and vertical variables
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            // to get player to snap to forward direction when changing dirn with WASD
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // move player when obtaining an input (>=0.1f)
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.SimpleMove(Vector3.forward * 0);
            //controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
