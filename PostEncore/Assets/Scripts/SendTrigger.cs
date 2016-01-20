using UnityEngine;
using System.Collections;

public class SendTrigger : MonoBehaviour {

    public GameObject manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer==8)
        {
            Debug.Log("SUP PLAYER");
            if (!Ending.quit)
            {
                manager.SendMessage("DoExit");
                Ending.quit = true;
            }
        }
    }
}
