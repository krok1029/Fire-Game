using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;

public class ObjectSave : MonoBehaviour {
    private int objectID;
    private static int currentObjectID = 0;
    private Rigidbody rb;
    private GameObject Object;
    ParseObject gameObject = new ParseObject("GameObject");
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        Object = GetComponent<GameObject>();
        objectID = currentObjectID;
        currentObjectID++;
        if (PlayerPrefs.HasKey("ObjectPosition" + objectID.ToString())){
            transform.position = PlayerPrefsX.GetVector3("ObjectPosition" + objectID.ToString());
//            Debug.Log(transform.position[0]);
            transform.rotation = PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());

            rb.velocity=PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
            rb.angularVelocity= PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
            Debug.Log(true);
        }
        
    }
	
	
	void OnDestroy () {
        Save();
    }
    public void Save()
    {
        PlayerPrefsX.SetVector3("ObjectPosition" + objectID.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion("ObjectRotation" + objectID.ToString(), transform.rotation);

        //PlayerPrefsX.SetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
        //PlayerPrefsX.SetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);

       
            gameObject["ObjectNum"+objectID] =  objectID;
            gameObject["PositionY"] = transform.position.y;
            gameObject["PositionX"] = transform.position.x;
            gameObject["PositionZ"] = transform.position.z;
            //gameObject["Rotation"] = PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());
            //gameObject["Velocity"] = PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
            //gameObject["AngularVelocity"] = PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
            Task saveTask = gameObject.SaveAsync();
            ParseObject testObject = new ParseObject("TestObject");
            testObject["foo"] = "bar";
            testObject.SaveAsync();
        
    }
}
