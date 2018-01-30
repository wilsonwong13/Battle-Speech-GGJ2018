using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

    public int timeRemaining;
    Text timerText;
    int ROUND_LENGTH = 30;
    GameManager gameManager;
    public Button nextButton;
    void Awake() {
        gameManager = GameObject.Find("UpdateGameManager").GetComponent<GameManager>();
	    timeRemaining = ROUND_LENGTH;
        timerText = GameObject.Find("GameClock").GetComponent<Text>();
    }

    public void StartTime(int duration) {
        // Must use named coroutine so StopCoroutine() invokes on correct IEnumerator instance below!
        Debug.Log("Starting count down");
        StartCoroutine("Countdown", duration);
    }

    public void ResetTimerAndStart() {
	    ClearTime();
	    timeRemaining = ROUND_LENGTH;
	    StartTime(ROUND_LENGTH);
    }

    public void DisableButton()
    {
        nextButton.gameObject.SetActive(false);
    }

    public void ClearTime () {
	    StopTime();
	    timerText.text = "0";
	    timerText.color = Color.white;
    }

    public void StopTime() {
	    timeRemaining = 1; // Prevents defeat from playing on a win!
	    StopCoroutine("Countdown");
        gameManager.EndRound();
    }

    public void ClearText()
    {
        timerText.text = "";
    }

    IEnumerator Countdown(int duration) {
	    for (var i = duration; i >= 0; i--) {
		    timerText.text = i.ToString();
		    if (i <= 2) {
			    timerText.color = Color.red;
		    }
		    timeRemaining = i;
            if(i == 0)
            {
                timerText.text = "Stop";
                gameManager.EndRound();
                nextButton.gameObject.SetActive(true);
            }
		    yield return new WaitForSecondsRealtime(1);
        }
    }

}
