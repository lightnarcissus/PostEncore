using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class AnimationPlay : MonoBehaviour {

    private float playTimer = 0f;
    private bool clapping = false;
    public GameObject mainCam;
    private float waitTimer = 0f;
    public GameObject curtain;
    public GameObject player;
    public GameObject hands;
    private bool once = true;
    private float drawTimer = 0f;
    private bool drawOut = true;
    private Quaternion neededRotation;
	public GameObject left;
	public GameObject right;

	// Use this for initialization
	void Start () {

        player.GetComponent<MouseLook>().enabled = false;
        mainCam.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        hands.GetComponent<Animator>().enabled = false;
        hands.GetComponent<AudioSource>().enabled = false;
        mainCam.GetComponent<Vignetting>().enabled = true;

	}
	
	// Update is called once per frame
	void Update () {


        if(drawOut)
        {
            drawTimer += Time.deltaTime;
            if(drawTimer>=0.66f)
            {
                if(hands.GetComponent<Animator>().enabled)
                {
                   // Debug.Log("nope");
                    hands.GetComponent<Animator>().enabled = false;
                }
                else
                {
                   // Debug.Log("INSIDE TIMER");
                    hands.GetComponent<Animator>().enabled = true;
                }
                drawTimer = 0f;
                drawOut = false;
                
            }
        }

      /*  if(drawOut && clapping) // if clapping and hands are out
        {
            hands.GetComponent<Animator>().enabled = false;
        }
        else if(drawOut && !clapping) //not clapping and hands are out
        {
            hands.GetComponent<Animator>().enabled = true;
        }
        else if(!drawOut && clapping) // clapping and not out
        {
            hands.GetComponent<Animator>().enabled = true;
        }*/

        if(CheckXML.input)
        {
           clapping=true;
			CheckXML.input=false;   
        }
        if (clapping)
        {
            neededRotation = Quaternion.LookRotation(curtain.transform.position - player.transform.position);
            if(!once)
            drawOut = true;
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, neededRotation, Time.deltaTime * 6f);
            hands.GetComponent<AudioSource>().enabled = true;
            player.GetComponent<MouseLook>().enabled = false;
            mainCam.GetComponent<MouseLook>().enabled = false;

            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            waitTimer = 0f;
            playTimer += Time.deltaTime;
			left.GetComponent<Animator>().enabled = true;
			right.GetComponent<Animator>().enabled=true;
            if (playTimer < 0.27f)
            {


                
            }
            else
            {
				left.GetComponent<Animator>().enabled = false;
				right.GetComponent<Animator>().enabled = false;
                hands.GetComponent<AudioSource>().enabled = false;
                clapping = false;
                playTimer = 0f;
            }
            if (mainCam.GetComponent<Vignetting>().intensity > 0.1f)
                mainCam.GetComponent<Vignetting>().intensity -= 0.1f;
            if (mainCam.GetComponent<Vignetting>().chromaticAberration > 0.1f)
                mainCam.GetComponent<Vignetting>().chromaticAberration -= 0.1f;

            if (mainCam.GetComponent<AudioLowPassFilter>().cutoffFrequency <= 4950)
                mainCam.GetComponent<AudioLowPassFilter>().cutoffFrequency += 100;
            //mainCam.GetComponent<Vignetting>().enabled = false;
        }
        else //not clapping
        {

            waitTimer += Time.deltaTime;
            if(waitTimer>1.2f)
            {
                drawOut = true;
                once = false;
                player.GetComponent<MouseLook>().enabled = true;
                mainCam.GetComponent<MouseLook>().enabled = true;
                player.GetComponent<Animator>().enabled = true;
                player.GetComponent<CharacterController>().enabled = true;

            }

            if (mainCam.GetComponent<Vignetting>().intensity < 10f)
                mainCam.GetComponent<Vignetting>().intensity += 0.1f;
            if (mainCam.GetComponent<Vignetting>().chromaticAberration < 20f)
                mainCam.GetComponent<Vignetting>().chromaticAberration += 0.1f;

            if (mainCam.GetComponent<AudioLowPassFilter>().cutoffFrequency >= 50)
                mainCam.GetComponent<AudioLowPassFilter>().cutoffFrequency -= 50;

        }

	
	}
}
