using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text;
using UnityEngine.VR;
public class CheckXML : MonoBehaviour {
	public static bool input=false;
    public Animator clapper;
	// Use this for initialization
	void Start () {
        VRSettings.renderScale = 2f;
	}
	
	// Update is called once per frame
	void Update () {

		StreamReader r = System.IO.File.OpenText("C:/Users/Ansh/Desktop/check.txt"); 
		string _info = r.ReadToEnd();
		r.Close ();
		//Debug.Log (_info);
		if(int.Parse(_info)==0)
		{
			//Debug.Log ("0");
			input=false;
            clapper.SetBool("Clapping", false);
		}
		if(int.Parse(_info)==1)
		{
			//Debug.Log ("1");
			input=true;
            clapper.SetBool("Clapping", true);
        }

	}
}
