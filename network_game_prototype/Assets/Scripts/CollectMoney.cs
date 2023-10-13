using ArcadeVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CollecMoney : NetworkBehaviour
{
    public ArcadeVehicleController _myAVC;
    
    private Inventory _inventory;



    // Start is called before the first frame update
    void Start()
    {
        _inventory= _myAVC.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Money count is " + _inventory.moneyCount);

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Picked up Money");

        if (col.gameObject.tag == "Player")
        {
            //_myAVC.GetComponent<Inventory>().boostCount ++;
            _inventory.moneyCount += 100;
            Debug.Log(_myAVC.GetComponent<Inventory>().moneyCount);

            //testing class from inventory - prob not working
            // _myAVC.GetComponent<Inventory>().PlayerItemsCount._moneyCount++;

            
        }
        //gameObject.SetActive(false);
    }
}
