using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //VARIABLES

    //Habitants(total)
    public int totalPeople = 20;
    public Text totalPeopleText;

    //Main d'oeuvre(habs dispos)
    public int labourCount;
    public Text labourCountText;

    //Bois
    public int woodCount = 10;
    public Text woodCountText;

    //Nourriture
    public int foodCount = 50;
    public Text foodCountText;
    public int foodQuantityPerFarm = 30;
    public int foodConsumPerPerson = 1;
    public bool FoodIsProducted = true;

    //Instance
    public static Inventory instance;

    private void Awake()
    {
        //Vérification et récupération instance
        if (instance != null)
        {
            Debug.LogWarning("Attention : Il y a plus d'une instance de Inventory dans la scène !");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        Initialisation();
        FoodProdAndConsum();
    }


    //**************************FONCTIONS UTILES*****************************//

    //Fonction ajout de bois
    public void AddWood(int count)
    {
        woodCount += count;
        woodCountText.text = woodCount.ToString();

    }

    //Fonction retrait de bois
    public void TakeWood(int count)
    {
        woodCount -= count;
        woodCountText.text = woodCount.ToString();
    }

    //Fonction ajout de nourriture
    public void AddFood(int count)
    {
        foodCount += count;
        foodCountText.text = foodCount.ToString();
    }

    //Fonction retrait de nouritture
    public void TakeFood(int count)
    {
        foodCount -= count;
        foodCountText.text = foodCount.ToString();
    }

    //Fonction ajout d'habitant
    public void AddPeople(int nb)
    {
        totalPeople += nb;
        labourCount += nb;
        totalPeopleText.text = totalPeople.ToString();
        labourCountText.text = labourCount.ToString();
    }

    //Fonction retrait de main d'oeuvre
    public void RemoveLabour(int nb)
    {
        labourCount -= nb;
        labourCountText.text = labourCount.ToString();
    }

    //Fonction ajout de main d'oeuvre
    public void AddLabour(int nb)
    {
        labourCount += nb;
        labourCountText.text = labourCount.ToString();
    }

    //************************ FONCTIONS UTILES ***************************//

    public void Initialisation()
    {
        labourCount = totalPeople;

        totalPeopleText.text = totalPeople.ToString();
        labourCountText.text = labourCount.ToString();

        foodCountText.text = foodCount.ToString();
        woodCountText.text = woodCount.ToString();
    }

    //************************ PRODUCTION NOURRITURE ***************************//

    public void FoodProdAndConsum()
    {
        StartCoroutine(FoodProductionTime(10f));
    }

    public IEnumerator FoodProductionTime(float time)
    {
        while (FoodIsProducted)
        {
            Debug.Log("Début attente");
            yield return new WaitForSeconds(time);
            Debug.Log("Fin attente");
            AddFood(foodQuantityPerFarm * (Construction.instance.numberOfFarm));
            Debug.Log(foodConsumPerPerson * totalPeople + " ont été consommés et " + foodQuantityPerFarm * Construction.instance.numberOfFarm + " ont été produites");
            TakeFood(foodConsumPerPerson * totalPeople);
        }       
    }

    //************************ PRODUCTION NOURRITURE ***************************//
}
