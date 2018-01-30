using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicManager : MonoBehaviour {
  AudioClip micClip;
  string micName;

  void Awake() {
    foreach (string device in Microphone.devices) {
      if (device == "Built-in Microphone") {
        micName = device;
        Debug.Log("Set up Microphone: " + device);
      }
    }
    StartRecording();
  }

  public void StartRecording() {
    AudioSource aud = GetComponent<AudioSource>();
    aud.clip = Microphone.Start(micName, true, 10, 44100);
    aud.Play();
  }

  public void StopRecording() {
    // Microphone.Stop();
  }
}
