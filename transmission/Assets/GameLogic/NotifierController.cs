using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NotifierController : MonoBehaviour {
    public Text notification;
  
    public void DisplayTheWinner(string text)
    {
        notification.text = text;
        notification.enabled = true;
    }

    public void DisplayTextOnTopOfScreen(string text, int duration) {
        StartCoroutine(FlashMessage(text, duration));
    }

    IEnumerator FlashMessage(string text, int duration) {
        notification.text = text;
        notification.enabled = true;
        yield return new WaitForSecondsRealtime(duration);
        HideNotificationText();
    }

    public void HideNotificationText() {
        notification.enabled = false;
    }

    public bool isDisplayed() {
        return notification.enabled;
    }

}
