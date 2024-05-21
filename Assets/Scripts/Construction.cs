using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{

    public int labourAskedToWorkInFarm = 10;
    public int labourGivenPerQuarter = 20;
    public int woodCostToBuildFarm = 10;
    public int woodCostToBuildQuarter = 40;

    public int numberOfFarm = 0;
    public int numberOfQuarter = 0;
    
    public bool caseIsEmpty;
    private bool caseIsEmptyLocal;
    public bool isBuilding = false;

    //Instance
    public static Construction instance;

    private void Awake()
    {
        //Vérification et récupération instance
        if (instance != null)
        {
            Debug.LogWarning("Attention : Il y a plus d'une instance de Construction dans la scène !");
            return;
        }

        instance = this;
    }

    ///////////////////////////////// CONSTRUCTION FERME /////////////////////////////////////////

    public void BuildAfarm(GameObject go)
    {
        caseIsEmptyLocal = caseIsEmpty;

        if (caseIsEmptyLocal == true && isBuilding == false)
        {
            if (Inventory.instance.woodCount >= woodCostToBuildFarm)
            {
                CanvasManager.instance.ClosePrairieCaseUI();
                Inventory.instance.RemoveLabour(labourAskedToWorkInFarm);
                Inventory.instance.TakeWood(woodCostToBuildFarm);
                isBuilding = true;
                StartCoroutine(EnumBuildFarm(go));
            }         
        }     
    }

    public IEnumerator EnumBuildFarm(GameObject go)
    {
        Debug.Log("Début coroutine");
        yield return new WaitForSeconds(5f);
        numberOfFarm += 1;
        Debug.Log("Fin coroutine");
        go.SetActive(true);
        isBuilding = false;
        caseIsEmptyLocal = false;
    } 

    //Auxiliaire de BuildAFarm()
    public void BuildAFarm_2()
    {
        BuildAfarm(ClickDetection.instance.farm);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    ///////////////////////////////// CONSTRUCTION QUARTIER //////////////////////////////////////

    public void BuildAQuarter(GameObject go)
    {
        caseIsEmptyLocal = caseIsEmpty;

        if (caseIsEmptyLocal == true && isBuilding == false)
        {
            if (Inventory.instance.woodCount >= woodCostToBuildQuarter)
            {
                CanvasManager.instance.ClosePrairieCaseUI();
                Inventory.instance.TakeWood(woodCostToBuildQuarter);
                isBuilding = true;
                StartCoroutine(EnumBuildQuarter(go));
            }          
        }
    }

    public IEnumerator EnumBuildQuarter(GameObject go)
    {
        Debug.Log("Début coroutine");
        yield return new WaitForSeconds(5f);
        Debug.Log("Fin coroutine");
        numberOfQuarter += 1;
        Inventory.instance.AddPeople(labourGivenPerQuarter);
        go.SetActive(true);
        isBuilding = false;
        caseIsEmptyLocal = false;
    }

    //Auxiliaire de BuildAFarm()
    public void BuildAQuarter_2()
    {
        BuildAQuarter(ClickDetection.instance.quarter);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////

}
