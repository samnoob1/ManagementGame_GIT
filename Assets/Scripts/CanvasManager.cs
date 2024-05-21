using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject forestCasePanel;
    public GameObject prairieCasePanel;
    public bool anUIisOpen = false;

    public static CanvasManager instance;

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

    public void OpenForestCaseUI()
    {
        forestCasePanel.SetActive(true);
        anUIisOpen = true;
    }

    public void CloseForestCaseUI()
    {
        forestCasePanel.SetActive(false);
        anUIisOpen = false;
        ClickDetection.instance.selectedCaseIcon.SetActive(false);
    }

    public void OpenPrairieCaseUI()
    {
        prairieCasePanel.SetActive(true);
        anUIisOpen = true;
    }

    public void ClosePrairieCaseUI()
    {
        prairieCasePanel.SetActive(false);
        anUIisOpen = false;
        ClickDetection.instance.selectedCaseIcon.SetActive(false);
    }
}
