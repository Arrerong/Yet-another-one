using Cinemachine;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    
    private int currentPlayerIndex;

    public CinemachineFreeLook[] cameras;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
        }
    }
    
    public bool IsItPlayerTurn(int index)
    {
        return index == currentPlayerIndex;
    }
    
    public static TurnManager GetInstance()
    {
        return instance;
    }
    
    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(true);
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 3;
            cameras[1].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(true);
        }
        else if (currentPlayerIndex == 3)
        {
            currentPlayerIndex = 4;
            cameras[2].gameObject.SetActive(false);
            cameras[3].gameObject.SetActive(true);
        }
        else if (currentPlayerIndex == 4)
        {
            currentPlayerIndex = 5;
            cameras[3].gameObject.SetActive(false);
            cameras[4].gameObject.SetActive(true);
        }
        else if (currentPlayerIndex == 5)
        {
            currentPlayerIndex = 6;
            cameras[4].gameObject.SetActive(false);
            cameras[5].gameObject.SetActive(true);
        }
        else if (currentPlayerIndex == 6)
        {
            currentPlayerIndex = 1;
            cameras[5].gameObject.SetActive(false);
            cameras[0].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            ChangeTurn();
        }
    }
}