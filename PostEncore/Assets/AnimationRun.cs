using UnityEngine;
using System.Collections;

public class AnimationRun : MonoBehaviour {

    private float maxTimer = 0f;
    private bool once = true;
    private float waitTimer = 0f;
    private float randChance = 0f;
    private bool playing = false;
    private float playTimer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (once)
        {
            if (gameObject.name == "Run")
                maxTimer = 4.06f;
            if (gameObject.name == "Walk")
                maxTimer = 6.1f;
            once = false;

        }
        else
        {
            if(waitTimer<5f)
            {
                waitTimer += Time.deltaTime;  
            }
            else
            {
                randChance = Random.value;
                if (randChance < 0.5f)
                {
                    playing = true;
                    gameObject.GetComponent<Animator>().enabled = true;
                }
                waitTimer = 0f;
            }

            if(playing)
            {
                playTimer += Time.deltaTime;
                if(playTimer>=maxTimer)
                {
                    playTimer = 0f;
                    gameObject.GetComponent<Animator>().enabled = false;
                    playing = false;
                }
            }
         }
	
	}
}
