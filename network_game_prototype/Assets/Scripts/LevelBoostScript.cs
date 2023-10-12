using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using ArcadeVP;
using Cinemachine;

public class LevelBoostScript : NetworkBehaviour
{

    
    public ArcadeVehicleController myAVC;
    public float impusleForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.gameObject.tag == "boost")
        {
            
            myAVC.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * impusleForce ,ForceMode.Impulse);
            //adds force to relative or local position > working decently for now
            
        }
    }


}
