using ArcadeVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCount
{
    public float _boostCount;
    public float _moneyCount;

    public ItemsCount(float _boostCount, float _moneyCount) 
    
    { 

        this._boostCount= _boostCount;
        this._moneyCount= _moneyCount;

    }

}
public class Inventory : MonoBehaviour
{
    

    public float boostCount;
    public float moneyCount;

    public ItemsCount PlayerItemsCount;


    // Start is called before the first frame update
    void Start()
    {
         PlayerItemsCount = new ItemsCount(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
