using ArcadeVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CollectBoost : NetworkBehaviour
{
    public ArcadeVehicleController _myAVC;
    
    public Inventory _inventory;



    // Start is called before the first frame update
    void Start()
    {
        _inventory= _myAVC.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Boost count is " + _inventory.boostCount);

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Picked up Boost");

        if (col.gameObject.tag == "Player")
        {
            //_myAVC.GetComponent<Inventory>().boostCount ++;
            _inventory.boostCount++;
            Debug.Log(_myAVC.GetComponent<Inventory>().boostCount);

            //testing class from inventory - prob not working
            // _myAVC.GetComponent<Inventory>().PlayerItemsCount._moneyCount++;

            
        }
        //gameObject.SetActive(false);
    }
}
