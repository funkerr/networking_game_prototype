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
            Debug.Log(other.gameObject.tag);
            myAVC.GetComponent<Rigidbody>().AddForce(Vector3.right * impusleForce ,ForceMode.Impulse);
            Debug.Log("added force");
        }
    }


}
