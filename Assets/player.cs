using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Transform cam_trans; public Camera cam;
    public Rigidbody player_body;

    public float walkspeed = 0.5f, runspeed = 2, jump_speed = 5;
    public bool jumping = true;

    float speed_mul = 1, mouse_sensx = 4, mouse_sensy = 2;

    Vector3 cur_rotation = new Vector3(0, 0, 0), last_trans = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //hide player's mouse
        Cursor.lockState = CursorLockMode.Locked;
        player_body = GetComponent<Rigidbody>();
        speed_mul = walkspeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 frame_vel = new Vector3(0, player_body.velocity.y, 0);
        if (Input.GetKey(KeyCode.LeftShift))
            speed_mul = runspeed;
        else
            speed_mul = walkspeed;

        if (Input.GetKey(KeyCode.W))
            frame_vel += transform.forward * speed_mul;
        if (Input.GetKey(KeyCode.S))
            frame_vel += -transform.forward * walkspeed;
        if (Input.GetKey(KeyCode.A))
            frame_vel += -transform.right * speed_mul;
        if (Input.GetKey(KeyCode.D))
            frame_vel += transform.right * speed_mul;
        if (Input.GetMouseButton(1))
        {
            cam.fieldOfView = cam.fieldOfView - 10 * Input.mouseScrollDelta.y;
            if (cam.fieldOfView < 10)
                cam.fieldOfView = 10;
            if (cam.fieldOfView > 60)
                cam.fieldOfView = 60;
        }
        else
            cam.fieldOfView = 60;
        //now lets make sure that the player is on the ground
        Ray ground_ray = new Ray(transform.position, -transform.up), lookray = new Ray(cam_trans.position, cam_trans.forward);
        if (Physics.Raycast(ground_ray, 2))
        {
            //now everything in here can only be done if the player is on the ground
            if (Input.GetKeyDown(KeyCode.Space) && jumping)
                frame_vel.y = jump_speed;
        }
        //set velocity
        player_body.velocity = frame_vel; //this plays with the physics engine in just the right way for movement to workout
        //handle rotation, we do it out here so the player can look around when they're dead
        cur_rotation.y += Input.GetAxis("Mouse X") * mouse_sensx; cur_rotation.x += Input.GetAxis("Mouse Y") * -mouse_sensy;
        if (cur_rotation.x > 90)
            cur_rotation.x = 90;
        if (cur_rotation.x < -95)
            cur_rotation.x = -95;
        transform.rotation = Quaternion.Euler(0, cur_rotation.y, 0); cam_trans.rotation = Quaternion.Euler(cur_rotation.x, cur_rotation.y, cur_rotation.z);
        last_trans = transform.position;
    }
}

