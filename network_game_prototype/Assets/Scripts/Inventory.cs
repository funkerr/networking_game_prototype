using ArcadeVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

//Testing class stuff, confused atm

//public class ItemsCount
//{
//    public float _boostCount;
//    public float _moneyCount;

//    public ItemsCount(float _boostCount, float _moneyCount) 
    
//    { 

//        this._boostCount= _boostCount;
//        this._moneyCount= _moneyCount;

//    }

//}
public class Inventory : NetworkBehaviour
{
    

    public int boostCount=0;
    public int moneyCount=0;
    

    // Start is called before the first frame update
    void Start()
    {


      boostCount = 0;
      moneyCount = 0;

    }
}

