using UnityEngine;
using System.Collections;

public class AudienceSounds : MonoBehaviour {

    public GameObject ovation;
    public GameObject tensecond;
    public AudioClip ovationClip;
    public GameObject shortApplause;
    public GameObject smallCrowd;
    public AudioClip smallCrowdClip;
    private float timer = 0f;
    private float randTimer = 0f;
    private int randClip = 0;
    public static bool ovationFlag = false;
	// Use this for initialization
	void Start () {
        shortApplause.SetActive(false);
        ovation.SetActive(false);
       // smallCrowd.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if(ovationFlag)
        {
          //  Debug.Log("OVATION");
            ovation.GetComponent<AudioSource>().PlayOneShot(ovationClip);
            ovationFlag = false;
        }

        if(timer<10f)
        {
            timer += Time.deltaTime;
              if(timer>9f && timer<10f)
            {
                shortApplause.SetActive(true);
            }
            if(timer>7f && timer<8f)
            {
                ovation.SetActive(true);
            }
        }
        else
        {
            if(randTimer<12f)
            randTimer += Time.deltaTime; 
            else
            {
               // Debug.Log("SUP");
                randClip = Random.Range(0,2);
                if (randClip == 1)
                {
                    //Debug.Log("UO!");
                    smallCrowd.GetComponent<AudioSource>().volume = MoveExit.masterVol;
                    smallCrowd.GetComponent<AudioSource>().PlayOneShot(smallCrowdClip);

                }

                randTimer = 0f;
            }
        }
      //  Debug.Log(timer);   
	}
}
