using UnityEngine;
using System.Collections;
using Parse;

public class ParseTry : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ParseObject testObject = new ParseObject("TestObject");
        testObject["foo"] = "bar";
        testObject.SaveAsync();
        Debug.Log("ok");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
