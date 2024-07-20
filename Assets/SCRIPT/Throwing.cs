using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    List<Vector3> trackingPos = new List<Vector3>();
    public float velocity = 1000f;

    bool pickUp = false;
    GameObject parentHand;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUp == true)
        {
            rb.useGravity = false;

            transform.position = parentHand.transform.position;
            transform.rotation = parentHand.transform.rotation;

            if(trackingPos.Count > 15){
                trackingPos.RemoveAt(0);
            }
            trackingPos.Add(transform.position);

            float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

            if(triggerRight < 0.1f)
            {
                pickUp = false;
                Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0];
                rb.AddForce(direction * velocity);
                rb.useGravity = true;
                rb.isKinematic = false;
                GetComponent<Collider>().isTrigger = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        Debug.Log("entro el trigger");
        if(other.gameObject.tag == "hand" && triggerRight > 0.9f)
        {
            pickUp = true;
            parentHand = other.gameObject;

        }
    }
}
