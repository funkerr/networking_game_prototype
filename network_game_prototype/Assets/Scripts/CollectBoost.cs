using ArcadeVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CollectBoost : NetworkBehaviour
{
    public ArcadeVehicleController _myAVC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Picked up boost");

        if (col.gameObject.tag == "Player")
        {
            _myAVC.GetComponent<Inventory>().boostCount ++;
            Debug.Log(_myAVC.GetComponent<Inventory>().boostCount);

            //testing class from inventory - prob not working
            // _myAVC.GetComponent<Inventory>().PlayerItemsCount._moneyCount++;
        }
        gameObject.SetActive(false);
    }
}
