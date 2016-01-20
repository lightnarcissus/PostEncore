using UnityEngine;
using System.Collections;

public class MoveExit : MonoBehaviour {
    public static float randTimer = 0f;
    private bool move = false;
    private float randVal = 0f;
    private float timer = 0f;
    public GameObject shortApplause;
    public static float masterVol = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(randTimer<3f)
        {
            randTimer += Time.deltaTime;
        }
        else
        {
            randVal = Random.value;
            randTimer = 0f;
        }

        if(randVal>0.95f)
        {
            //Debug.Log("MOVING NOW");
            shortApplause.GetComponent<AudioSource>().volume -= 0.01f;
            masterVol = shortApplause.GetComponent<AudioSource>().volume;
            gameObject.GetComponent<Animator>().enabled = true;
            move = true;
            transform.Find("Hand").GetComponent<Animator>().enabled = false;
            randVal = Random.value;
        }
        if(move)
        {
            if (timer < 7.8f)
                timer += Time.deltaTime;
            else
            {
               // Debug.Log("DEAD");
                timer = 0f;
                gameObject.SetActive(false);
            }
        }
	
	}
}
