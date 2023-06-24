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

            if (path.isArrived)
            {
                chooseButtons.SetActive(true);
                path.isArrived= false;
            }

        }

    }
    public void ChooseBlueTank()
    {
        if (currentTank != null)
        {
            currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = false;
        }
        currentTank = tanks[0];

        chooseButtons.SetActive(false);
        goToButtons.SetActive(true);
    }

    public void ChooseRedTank()
    {
        if (currentTank != null)
        {
            currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = false;
        }


        currentTank = tanks[1];

        chooseButtons.SetActive(false);
        goToButtons.SetActive(true);
    }

    public void ChooseGreenTank()
    {
        if (currentTank != null)
        {
            currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = false;
        }

        currentTank = tanks[2];


        chooseButtons.SetActive(false);
        goToButtons.SetActive(true);
    }

    public void GoToHelipad()
    {

        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[20]);
        path.currentWaypointIndex = 0;


        goToButtons.SetActive(false);
        
    }
    public void GoToRuins()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[7]);
        path.currentWaypointIndex = 0;


        goToButtons.SetActive(false);

    }


    public void GoToFactory()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[17]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);

    }

    public void GoToTwinMountains()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[3]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);

    }
    public void GotoBarracks()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[12]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);

    }
    public void GoToCommandCenter()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[5]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);

    }
    public void GoToOilRefinery()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[14]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);

    }
    public void GoToTankers()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[16]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);
    }
    public void GoToRadar()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[8]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);
    }
    public void GoToCommandPost()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[6]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);

    }
    public void GoToMiddle()
    {
        currentTank.GetComponent<FollowPath>().isCurrentSelectedTank = true;

        path.graph.AStar(path.currentNode, path.wps[13]);
        path.currentWaypointIndex = 0;

        goToButtons.SetActive(false);
    }
}
