using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMessageSender : MonoBehaviour {
    GameManager gameManager;

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void SendResponse(float sentimentScore)
    {
        if(gameManager.playerOneTurn)
        {
            gameManager.UpdatePlayerOneResponse(sentimentScore);
        }
        else if(gameManager.playerTwoTurn)
        {
            gameManager.UpdatePlayerTwoResponse(sentimentScore);
        }
    }
}
