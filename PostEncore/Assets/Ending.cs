using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {


    public GameObject manager;
    public static int randEnding = 0;
    private float mainTimer = 0f;
    private float quitTimer = 0f;
    public AudioClip draped;
    public GameObject mainCam;
    public GameObject oldPlayer;
    public GameObject whiteCam;
    public static bool quit = false;
    public GameObject audienceSounds;
    private bool yay = false;
	// Use this for initialization
	void Start () {
        
        randEnding = Random.Range(0, 4);
	}
	
	// Update is called once per frame
	void Update () {


      //  Debug.Log(randEnding);
        if (randEnding == 0)
        {
            mainTimer += Time.deltaTime;
            if (mainTimer > 237f && mainTimer<238f)
            {
                if (!yay)
                {
                    AudienceSounds.ovationFlag = true;
                    yay = true;
                }
                 mainCam.GetComponent<AudioListener>().enabled = false;
                manager.SendMessage("DoFade");
                whiteCam.GetComponent<AudioSource>().PlayOneShot(draped);
            }
            if(mainTimer>240f && mainTimer>241f)
            {
                quit = true;
            }


        }

        else if (randEnding == 2)
        {
            mainTimer += Time.deltaTime;
            if (mainTimer > 97f && mainTimer<98f) 
            {
                if (!yay)
                {
                    AudienceSounds.ovationFlag = true;
                    yay = true;
                }
               
                manager.SendMessage("DoFade");
                mainCam.GetComponent<AudioListener>().enabled = false;
                AudienceSounds.ovationFlag = true;
                whiteCam.GetComponent<AudioSource>().PlayOneShot(draped);
                   
            }
            if(mainTimer>100f && mainTimer<101f)
            {
               // manager.SendMessage("DoFade");
                quit = true;
            }
    
        }

        if (quit)
        {
        //    Debug.Log("ABOUT TO QUIT"); 

            quitTimer += Time.deltaTime;
            if (quitTimer > 5f)
            {
              //  Debug.Log("QUITTING");
                Application.Quit();
            }
        }

	
	}
}
