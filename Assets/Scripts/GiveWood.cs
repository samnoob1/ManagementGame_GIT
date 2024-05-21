using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveWood : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Inventory.instance.AddWood(50);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Inventory.instance.AddFood(50);
        }
    }
}
