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
        //V�rification et r�cup�ration instance
        if (instance != null)
        {
            Debug.LogWarning("Attention : Il y a plus d'une instance de Inventory dans la sc�ne !");
            return;
        }

        instance = this;
    }


    //Fonctions
    void Start()
    {
        Debug.Log("D�but des tests");
    }

    void Update()
    {
        clickDetection();
    }

    void clickDetection()
    {
        //D�tection du click
        if (Input.GetMouseButtonDown(0))
        {
            //Tir du raycast
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Touch� et v�rif UI non ouverte
            if (Physics.Raycast(ray, out hit, 100) && (CanvasManager.instance.anUIisOpen == false)) 
            {
                curSelectedObject = hit.transform.gameObject;
                selectedCaseIcon = curSelectedObject.transform.Find("caseSelectedIcon").gameObject;
                selectedCaseIcon.SetActive(true);

                if (curSelectedObject.tag == "for�t")
                {
                    trees = curSelectedObject.transform.Find("Arbres").gameObject;
                    CanvasManager.instance.OpenForestCaseUI();
                    Debug.Log("Vous avez s�lectionn� une case For�t");

                    if (trees.activeInHierarchy)
                    {

                        Construction.instance.caseIsEmpty = false;
                    }
                    else
                    {
                        Debug.Log("La case a d�j� �t� r�colt�");
                        Construction.instance.caseIsEmpty = true;
                    }
                }
                else if (curSelectedObject.tag == "prairie")
                {
                    Debug.Log("Vous avez s�lectionn� une case Prairie");

                    //Acc�s � la ferme et au quartier de la case prairie
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
                    Debug.Log("Vous avez s�lectionn� une case Eau");
                }
                else if (curSelectedObject.tag == "ville")
                {
                    Debug.Log("Vous avez s�lectionn� la case Ville");
                }
            }
        }
    }
}
