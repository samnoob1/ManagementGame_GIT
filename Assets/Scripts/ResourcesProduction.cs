using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesProduction : MonoBehaviour
{
    public int labourAskedToRecoltWood = 10;
    public bool isRecolting = false;
    private bool caseIsEmptyLocal;

    void Update()
    {

    }

    //******************** RÉCOLTE DE BOIS ************************//
    public void WoodRecolting(GameObject go)
    {
        caseIsEmptyLocal = Construction.instance.caseIsEmpty;

        if (caseIsEmptyLocal == false && isRecolting == false)
        {
            if(Inventory.instance.labourCount >= labourAskedToRecoltWood)
            {
                CanvasManager.instance.CloseForestCaseUI();
                isRecolting = true;
                StartCoroutine(EnumWoodRecolt(go));
            } 
        }          
    }

    public IEnumerator EnumWoodRecolt(GameObject go)
    {
        Inventory.instance.RemoveLabour(labourAskedToRecoltWood);
        
        yield return new WaitForSeconds(5f);

        go.SetActive(false);
        Inventory.instance.AddWood(50);
        Inventory.instance.AddLabour(labourAskedToRecoltWood);
        isRecolting = false;
        caseIsEmptyLocal = true;
    }
    
    
    //Auxiliaire de WoodRecolting()
    public void WoodRecolting_2()
    {
        WoodRecolting(ClickDetection.instance.trees);
    }

    //******************** RÉCOLTE DE BOIS ************************//
}