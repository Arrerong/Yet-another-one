using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    
    private int currentPlayerIndex;

    public List<ArvidMovement> players;

    float currentTime = 0f;
    float startingTime = 15f;

    public TMP_Text winText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 0;

            currentTime = startingTime;
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
        for (int i = 0; i < players.Count; i++)
        {
            currentPlayerIndex++;
            if (currentPlayerIndex >= players.Count)
            {
                currentPlayerIndex = 0;
            }
            if (players[currentPlayerIndex] != null)
            {
                return;
            }
        }
    }

    private int checkWinner()
    {
        bool baldies = false;
        bool haries = false;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
            {
                if (i % 2 == 0)
                {
                    haries = true;
                }
                else
                {
                    baldies = true;
                }
            }
        }
        if (baldies && haries)
        {
            return 0;
        }
        if (baldies)
        {
            return 2;
        }
        return 1;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            ChangeTurn();
            if (checkWinner() != 0)
            {
                winText.text = checkWinner() == 1 ? "Hairy Fucks win!" : "Bald Angels win!";
            }
            currentTime = startingTime;
        }
    }
}