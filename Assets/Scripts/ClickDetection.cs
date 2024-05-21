using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    //Variables
    public GameObject curSelectedObject;
    public GameObject trees;
    public GameObject farm;
    public GameObject quarter;
    public GameObject selectedCaseIcon;

    //Instance
    public static ClickDetection instance;

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


    //Fonctions
    void Start()
    {
        Debug.Log("Début des tests");
    }

    void Update()
    {
        clickDetection();
    }

    void clickDetection()
    {
        //Détection du click
        if (Input.GetMouseButtonDown(0))
        {
            //Tir du raycast
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Touché et vérif UI non ouverte
            if (Physics.Raycast(ray, out hit, 100) && (CanvasManager.instance.anUIisOpen == false)) 
            {
                curSelectedObject = hit.transform.gameObject;
                selectedCaseIcon = curSelectedObject.transform.Find("caseSelectedIcon").gameObject;
                selectedCaseIcon.SetActive(true);

                if (curSelectedObject.tag == "forêt")
                {
                    trees = curSelectedObject.transform.Find("Arbres").gameObject;
                    CanvasManager.instance.OpenForestCaseUI();
                    Debug.Log("Vous avez sélectionné une case Forêt");

                    if (trees.activeInHierarchy)
                    {

                        Construction.instance.caseIsEmpty = false;
                    }
                    else
                    {
                        Debug.Log("La case a déjà été récolté");
                        Construction.instance.caseIsEmpty = true;
                    }
                }
                else if (curSelectedObject.tag == "prairie")
                {
                    Debug.Log("Vous avez sélectionné une case Prairie");

                    //Accès à la ferme et au quartier de la case prairie
                    farm = curSelectedObject.transform.Find("farm").gameObject;
                    quarter = curSelectedObject.transform.Find("quarter").gameObject;
                    
                    //Ouverture UI Prairie
                    CanvasManager.instance.OpenPrairieCaseUI();

                    if(farm.activeInHierarchy || quarter.activeInHierarchy)
                    {
                        Debug.Log("La case n'est pas vide");
                        Construction.instance.caseIsEmpty = false;
                    }
                    else
                    {
                        Construction.instance.caseIsEmpty = true;
                    }
                    
                }
                else if (curSelectedObject.tag == "eau")
                {
                    Debug.Log("Vous avez sélectionné une case Eau");
                }
                else if (curSelectedObject.tag == "ville")
                {
                    Debug.Log("Vous avez sélectionné la case Ville");
                }
            }
        }
    }
}
