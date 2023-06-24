using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankChooser : MonoBehaviour
{
    private int chosenTank;
    [SerializeField] private List<GameObject> tanks;
    public GameObject currentTank;

    public FollowPath path;

    [SerializeField] private GameObject goToButtons;
    [SerializeField] private GameObject chooseButtons;

    private void Update()
    {
        if (currentTank != null)
        {
            path = currentTank.GetComponent<FollowPath>();
        }
    }
    public void ChooseBlueTank()
    {
        currentTank = tanks[0];

        chooseButtons.SetActive(false);
        goToButtons.SetActive(true);
    }

    public void ChooseRedTank()
    {
        currentTank = tanks[1];

        chooseButtons.SetActive(false);
        goToButtons.SetActive(true);
    }

    public void ChooseGreenTank()
    {
        currentTank = tanks[2];

        chooseButtons.SetActive(false);
        goToButtons.SetActive(true);
    }

    public void GoToHelipad()
    {

        path.graph.AStar(path.currentNode, path.wps[20]);
        path.currentWaypointIndex = 0;

        chooseButtons.SetActive(true);
        goToButtons.SetActive(false);
    }
    public void GoToRuins()
    {
        path.graph.AStar(path.currentNode, path.wps[7]);
        path.currentWaypointIndex = 0;

        chooseButtons.SetActive(true);
        goToButtons.SetActive(false);

    }
}
