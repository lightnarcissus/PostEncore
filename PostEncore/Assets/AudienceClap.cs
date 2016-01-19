using UnityEngine;
using System.Collections;

public class AudienceClap : MonoBehaviour {

    private float randTimer = 0f;
    private bool clapping = false;
    private float randVal = 0f;
    private bool active = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        randTimer += Time.deltaTime;
        if (randTimer > 3f)
        {
            if (!clapping)
            {
                    gameObject.GetComponent<Animator>().enabled = true;
                    clapping = true;

            }
            randVal = Random.value;
            if (randVal > 0.9f)
            {
                active = true;
                randVal = 0f;
            }
            randTimer = 0f;
        }

        if (active)
        {

                gameObject.GetComponent<Animator>().enabled = false;
                clapping = false;
                active = false;
        }

	
	}
}
