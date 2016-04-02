using UnityEngine;
using System.Collections;

public class MicrophonePlayback : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioSource aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        aud.Play();
    }
	
	// Update is called once per frame
	void Update () {
       

    }
}
