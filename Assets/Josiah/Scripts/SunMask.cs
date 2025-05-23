using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SunMask : Mask
{
    public GameObject player;
    public Transform holdPos;

    public float pickUpRange = 5f; //how far the player can pickup the object from
    private GameObject heldObj; //object which we pick up
    private Rigidbody heldObjRb; //rigidbody of object we pick up
    private bool canDrop = true; //this is needed so we don't throw/drop object when rotating the object
    private int LayerNumber; //layer index
    public GameObject flame;



    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer"); //if your holdLayer is named differently make sure to change this ""

        //mouseLookScript = player.GetComponent<MouseLookScript>();
    }

    public override void Behaviour(PlayerMovement player)
    {
        if (player.GetComponent<PlayerInput>().actions["Flame Hold"].WasReleasedThisFrame() && heldObj != null)
        {
            DeleteObject();
        }

        if (heldObj != null) //if player is holding object
        {
            MoveObject(); //keep object position at holdPos
            if (player.GetComponent<PlayerInput>().actions["Flame Hold"].WasPressedThisFrame() && canDrop == true) //Mous0 (leftclick) is used to throw, change this if you want another button to be used)
            {
                StopClipping();
            }
        }
    }

    void PickUpFlame(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            GameObject newPickUpObject = Instantiate(GetComponent<SunMask>().flame);

            heldObj = newPickUpObject; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = newPickUpObject.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer

            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPos.transform.position;
    }

    void DeleteObject()
    {
        Destroy(heldObj);
    }
    
    void StopClipping() //function only called when dropping/throwing
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
        //have to use RaycastAll as object blocks raycast in center screen
        //RaycastAll returns array of all colliders hit within the cliprange
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
        if (hits.Length > 1)
        {
            //change object position to camera position 
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
            //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
        }
    }

    public void CheckToGrabFlame()
    {
        if (GetComponent<PlayerMovement>().currentMask != this)
            return;

        // if you hold left click
        if (heldObj == null) //if currently not holding anything
        {
            //perform raycast to check if player is looking at object within pickuprange
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, pickUpRange))
            {
                //make sure Brazier Flame tag is attached
                if (hit.transform.gameObject.CompareTag("Brazier Flame"))
                {
                    //pass in object hit into the PickUpFlame function
                    PickUpFlame(hit.transform.gameObject);
                }
            }
        }
        else
        {
            if (canDrop == true)
            {
                StopClipping(); //prevents object from clipping through walls
            }
        }
        
    }

    public override void EquipMask()
    {
    }

    public override void UnequipMask()
    {
    }
}