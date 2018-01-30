using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    [SyncVar]
    bool isRecording;

    void Update() {
        if (!isLocalPlayer)
        {
            return;
        }

        transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }
}
