using System;
using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Services.TradeoffAnalytics.v1;
using UnityEngine;

public class FireCannonball : MonoBehaviour {
    public GameObject ball;
    public Transform target;
    public float speed;
    private Boolean notFired = true;
    
    public void FireCannonBall()
    {
        Debug.Log("CANNONBALL: ", this.ball);
        GameObject newCannonBall = Instantiate(this.ball, gameObject.transform.position, Quaternion.identity);
        Vector3 vectorDirection = target.transform.position - gameObject.transform.position * speed;
        vectorDirection.y = 8;
        Debug.Log("VECTOR DIRECITON: " + vectorDirection);
        newCannonBall.GetComponent<Rigidbody>().velocity = vectorDirection;
        newCannonBall.GetComponent<AudioSource>().Play();
    }

}
