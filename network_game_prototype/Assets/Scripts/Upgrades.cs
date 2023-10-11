using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class carUpgrades
{
    public int itemID;
    public string name;
    public GameObject itemPrefab;

}

public class Upgrades : MonoBehaviour
{
    // Start is called before the first frame update


    //nitro
    //tires
    //shocks
    //acceleration
    //topspeed
    public carUpgrades _nitro;
     

    void Start()
    {
        _nitro = new carUpgrades();
        Debug.Log(_nitro.itemID + _nitro.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
