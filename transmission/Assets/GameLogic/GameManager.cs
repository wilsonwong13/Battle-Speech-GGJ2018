using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    private TimeController timeController;
    // Positive Sentiment
    [SerializeField]
    private float playerOneResponse = 0;
    // Negative Sentiment
    [SerializeField]
    private float playerTwoResponse = 1;
    private bool gameStarted = false;
    private NotifierController notifierController;
    private WatsonManager watsonManager;
    private WeatherManager weatherManager;
    public bool playerOneTurn = true;
    public bool playerTwoTurn = false;
    private int playerOneHealth = 2;
    private int playerTwoHealth = 2;
    private FireCannonball playerOneCannons;
    private FireCannonball playerTwoCannons;

    public Text currentScoreDisplay; 
    //Player 1 = Postive 
    //Player 2 = Negative
    void Awake()
    {
        timeController = transform.GetComponent<TimeController>();
        notifierController = GameObject.Find("UI/Notifier").GetComponent<NotifierController>();
        weatherManager = GameObject.Find("WeatherManager").GetComponent<WeatherManager>();
        watsonManager = GameObject.Find("Main Camera").GetComponent<WatsonManager>();
        playerOneCannons = GameObject.Find("Player 1 - Postive").GetComponent<FireCannonball>();
        playerTwoCannons = GameObject.Find("Player 2 - Negative").GetComponent<FireCannonball>();
    }

    void Start () {
        // SetUpComponents();
        // Find reference to WeatherManager
        BeginRound();
    }

    public void NextAction()
    {
        if (playerOneResponse == 0 || playerTwoResponse == 1)
        {
            BeginRound();
        }
        else if (playerOneResponse != 0 && playerTwoResponse != 1)
        {
            RunAnalyzer();
        }
    }

    public void BeginRound()
    {
        Debug.Log("Begin Round");
        timeController.ClearText();
        timeController.DisableButton();
        StartCoroutine(GetReady());
        gameStarted = true;
    }

    public void RunAnalyzer()
    {
        //float totalSum = playerOneResponse + playerTwoResponse;
        /*if(totalSum > 0)
        {
            playerTwoHealth -= 1;
            weatherManager.IncrementWeatherState();
        } 
        else if(totalSum < 0)
        {
            playerOneHealth -= 1;
            weatherManager.DecrementWeatherState();
        }*/

        float NegDiff = playerTwoResponse - 0;
        float PosDiff = 1 - playerOneResponse;
        if(NegDiff > PosDiff)
        {
            playerOneCannons.FireCannonBall();
            playerTwoHealth -= 1;
            weatherManager.IncrementWeatherState();
            currentScoreDisplay.text = "Navy Won that round!\nCurrent Health\nNavy: " + playerOneHealth + "\nEvil Pirates: " + playerTwoHealth;
            currentScoreDisplay.color = Color.white;
        }
        else if(PosDiff > NegDiff)
        {
            playerTwoCannons.FireCannonBall();
            playerOneHealth -= 1;
            weatherManager.DecrementWeatherState();
            currentScoreDisplay.text = "Evil Pirates Won that round!\nCurrent Health\nPostive: " + playerOneHealth + "\nNegative: " + playerTwoHealth;
            currentScoreDisplay.color = Color.white;
        }
        else if (PosDiff == NegDiff)
        {
            currentScoreDisplay.text = "Tied!";
            currentScoreDisplay.color = Color.white;
        }

        if(playerTwoHealth <= 0 )
        {
            string message = "Navy Wins";
            notifierController.DisplayTheWinner(message);
            Debug.Log(message);
            weatherManager.IncrementWeatherState();
            currentScoreDisplay.text = "";
            timeController.ClearText();
        }
        else if(playerOneHealth <= 0)
        {
            string message = "Evil Pirates Wins!";
            notifierController.DisplayTheWinner(message);
            Debug.Log(message);
            weatherManager.DecrementWeatherState();
            currentScoreDisplay.text = "";
            timeController.ClearText();    
        }
        Debug.Log("player one health: " + playerOneHealth);
        Debug.Log("player two health: " + playerTwoHealth);
        playerOneResponse = 0;
        playerTwoResponse = 1;
    }

    void GameOver()
    {
        //Game Over Sign 
    }

    public void UpdatePlayerOneResponse(float response)
    {
        if(playerOneResponse < response)
        {
            playerOneResponse = response;
        }
        //playerOneResponse += response;
        Debug.Log("Player One Current Score: " + playerOneResponse);
        currentScoreDisplay.text = "Current Score: " + playerOneResponse;
    }
    
    public void UpdatePlayerTwoResponse(float response)
    {
        if(playerTwoResponse > response)
        {
            playerTwoResponse = response;
        }
        //playerTwoResponse += response;
        Debug.Log("Player Two Current Score: " + playerTwoResponse);
        currentScoreDisplay.text = "Current Score: " + playerTwoResponse;
    }

    IEnumerator GetReady() {
        // PlayMusic();
        notifierController.DisplayTextOnTopOfScreen("Get Ready", 3);
        yield return new WaitForSecondsRealtime(3);
        notifierController.DisplayTextOnTopOfScreen("3", 1);
        yield return new WaitForSecondsRealtime(1);
        notifierController.DisplayTextOnTopOfScreen("2", 1);
        yield return new WaitForSecondsRealtime(1);
        notifierController.DisplayTextOnTopOfScreen("1", 1);
        yield return new WaitForSecondsRealtime(1);
        var emotionString = playerEmotion();
        notifierController.DisplayTextOnTopOfScreen(emotionString, 1);
        yield return new WaitForSecondsRealtime(1);
        StartRound();
        currentScoreDisplay.text = "";
    }

    void StartRound() {
        watsonManager.EnableWatsonSST();
        timeController.StartTime(10);
        // RPC start recording
    }

    public void EndRound() {
        watsonManager.DisableWatsonSST();
        if(playerOneTurn == true)
        {
            playerOneTurn = false;
            playerTwoTurn = true;
        }
        else if(playerTwoTurn == true)
        {
            playerOneTurn = true;
            playerTwoTurn = false;
        }
        Debug.Log("Ending Round");
        // RPC End recording
    }

    public string playerEmotion()
    {
        if (playerOneTurn == true)
        {
            return "SPEAK POSITIVELY";

        }
        else if (playerTwoTurn == true)
        {
            return "SPEAK NEGATIVELY";
        }
        return "Error";
    }
}
