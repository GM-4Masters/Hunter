using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionOption : MonoBehaviour
{
    [SerializeField] private GameObject selectionPanel;
    [SerializeField] private GameObject simulationPanel;
    //[SerializeField] private GameObject resultPanel;

    private SimulationPopup simulationPopup;
    //private ResultPopup resultPopup;

    private int actionIndex;
    private int optionIndex;

    private void Start()
    {
        simulationPopup = simulationPanel.GetComponent<SimulationPopup>();
        //resultPopup = resultPanel.GetComponent<ResultPopup>();
    }

    public void SetIndex(int actIndex, int optIndex)
    {
        actionIndex = actIndex;
        optionIndex = optIndex;
    }

    public void OnClick()
    {
        selectionPanel.SetActive(false);
        simulationPanel.SetActive(true);
        simulationPopup.SetPopup(actionIndex, optionIndex);

    }
}
