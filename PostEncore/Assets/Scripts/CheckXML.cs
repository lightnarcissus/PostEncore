using UnityEngine;
using System.Collections;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text;

public class CheckXML : MonoBehaviour {
	public static bool input=false;
	// Use this for initialization
	void Start () {
	
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
		}
		if(int.Parse(_info)==1)
		{
			//Debug.Log ("1");
			input=true;
		}

	}
}
