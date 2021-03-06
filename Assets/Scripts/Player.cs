using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform camTrans; public Camera cam;
    public Rigidbody playerBody;
    public Team team; //the team of this player

    public float walkAcceleration = 8, runAcceleration = 12, jumpSpeed = 200;
    //there is a difference between acceleration and speed btw
    public float maxSpeed = 12;

    float speedMul = 1, mouseSensX = 4, mouseSensY = 2;

    public Item[] quickSlots = {null, null, null, null, null};
    public Item holding;

    public Transform hand;

    public Text objectDisplayName, objectDisplayDescription;

    Vector3 curRotation = new Vector3(0, 0, 0), last_trans = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //hide player's mouse
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = GetComponent<Rigidbody>();
        speedMul = walkAcceleration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speedMul = runAcceleration;
        else
            speedMul = walkAcceleration;

        if (Input.GetKey(KeyCode.W))
            playerBody.AddForce(transform.forward * speedMul, ForceMode.Force);
        if (Input.GetKey(KeyCode.S))
            playerBody.AddForce(-transform.forward * walkAcceleration, ForceMode.Force);
        if (Input.GetKey(KeyCode.A))
            playerBody.AddForce(-transform.right * speedMul, ForceMode.Force);
        if (Input.GetKey(KeyCode.D))
            playerBody.AddForce(transform.right * speedMul, ForceMode.Force);

        //handling bindings
        if (Input.GetKey(KeyCode.Q))
            SetHold(quickSlots[0]);
        if (Input.GetKey(KeyCode.E))
            SetHold(quickSlots[1]);
        if (Input.GetKey(KeyCode.F))
            SetHold(quickSlots[2]);
        if (Input.GetKey(KeyCode.C))
            SetHold(quickSlots[3]);
        if (Input.GetKey(KeyCode.LeftAlt))
            SetHold(quickSlots[4]);

        if (holding)
            holding.WhileHeld();

        //for zooming, might use this part for binocs (idk if i should disable this rn or not so it stays for testing)
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
        Ray ground_ray = new Ray(transform.position, -transform.up), lookray = new Ray(camTrans.position, camTrans.forward);
        if (Physics.Raycast(ground_ray, 2))
        {
            //now everything in here can only be done if the player is on the ground
            if (Input.GetKeyDown(KeyCode.Space) && jumpSpeed > 0)
                playerBody.AddForce(transform.up * jumpSpeed, ForceMode.Force);
        }
        RaycastHit info;
        if (Physics.Raycast(lookray, out info, 7))
        {
            if(info.collider.gameObject.tag == "Object")
            {
                Object tmp = info.collider.gameObject.GetComponent<Object>();
                objectDisplayName.text = tmp.displayName;
                objectDisplayDescription.text = tmp.toolTip;
                if (Input.GetKey(KeyCode.Q))
                    tmp.PickUp(this, 0);
            }

        }
        playerBody.drag = 1.0f - (maxSpeed - (playerBody.velocity.magnitude - Mathf.Abs(playerBody.velocity.y))) / maxSpeed; 
        //handle rotation, we do it out here so the player can look around when they're dead
        curRotation.y += Input.GetAxis("Mouse X") * mouseSensX; curRotation.x += Input.GetAxis("Mouse Y") * -mouseSensY;
        if (curRotation.x > 90)
            curRotation.x = 90;
        if (curRotation.x < -95)
            curRotation.x = -95;
        transform.rotation = Quaternion.Euler(0, curRotation.y, 0); camTrans.rotation = Quaternion.Euler(curRotation.x, curRotation.y, curRotation.z);
        last_trans = transform.position;
    }

    void SetHold(Item item)
    {
        for(int i = 0; i < hand.childCount; i++)
            Destroy(hand.GetChild(i).gameObject);
        holding = null;
        if (hand.childCount == 0 && item)
        {
            GameObject tmp = Instantiate(item.model, hand);
            tmp.transform.position = hand.transform.position;
            holding = tmp.GetComponent<Item>();
        }
    }
}

