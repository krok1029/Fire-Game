using UnityEngine;
using System.Collections;

public class ObjectSave : MonoBehaviour {
    private int objectID;
    private static int currentObjectID = 0;
    private Rigidbody rb;
    private GameObject Object;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        Object = GetComponent<GameObject>();
        objectID = currentObjectID;
        currentObjectID++;
        if (PlayerPrefs.HasKey("ObjectPosition" + objectID.ToString())){
            transform.position = PlayerPrefsX.GetVector3("ObjectPosition" + objectID.ToString());
            transform.rotation = PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());

            rb.velocity=PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
            rb.angularVelocity= PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
           
        }
        
	}
	
	
	void OnDestroy () {
	    PlayerPrefsX.SetVector3("ObjectPosition" + objectID.ToString(),transform.position);
        PlayerPrefsX.SetQuaternion("ObjectRotation" + objectID.ToString(), transform.rotation);

        PlayerPrefsX.SetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
        PlayerPrefsX.SetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
    
        
        
    }

}
