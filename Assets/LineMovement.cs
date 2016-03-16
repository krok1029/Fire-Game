using UnityEngine;
using System.Collections;

public class LineMovement : MonoBehaviour {

	void Update () {
		gameObject.transform.Translate (3*Time.deltaTime, 0, 2*Time.deltaTime);
	}
}