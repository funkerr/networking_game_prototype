using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class carUpgrades
{
    public int itemID;
    public string name;
    public GameObject itemPrefab;
    public GameObject myPrefab;

    public carUpgrades(int itemID, string name)
    {
        this.itemID = itemID;
        this.name = name;
        //this.itemPrefab = itemPrefab;

    }

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
       _nitro = new carUpgrades(1, "Nitro");
        Debug.Log(_nitro);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
