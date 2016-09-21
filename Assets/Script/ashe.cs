using UnityEngine;
using System.Collections;

public class ashe : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        this.GetComponentInChildren<Renderer>().enabled = false;
        InvokeRepeating("appear", 4f, 600000f);
	}
    void appear() {
        this.GetComponentInChildren<Renderer>().enabled = true;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
