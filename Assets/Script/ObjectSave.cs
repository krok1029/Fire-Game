using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;


public class ObjectSave : MonoBehaviour {
    private static int objectID;
    private static int currentObjectID = 0;
    private Rigidbody rb;
 //   private GameObject Object;
      // public Text tx;
    
    // Use this for initialization
    void Start () {
      //  tx = GetComponent<Text>();
        rb = GetComponent<Rigidbody>();
        //Object = GetComponent<GameObject>();
        objectID = currentObjectID;
        currentObjectID++;
        if (PlayerPrefs.HasKey(this.gameObject.name + objectID.ToString())){
            //transform.position = PlayerPrefsX.GetVector3("ObjectPosition" + objectID.ToString());
            //Debug.Log("ObjectPosition" + objectID.ToString());
            transform.rotation = new Quaternion(0,0,0,0);//PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());

            rb.velocity=PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
            rb.angularVelocity= PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
            
        }
     
        //Debug.Log(transform.position.x);
        //Debug.Log(this.gameObject.name+objectID);
    }
	
	
	void OnDestroy () {
        Save();
    }
    public void Save()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        PlayerPrefsX.SetVector3(this.gameObject.name + objectID.ToString(), transform.position);
        //PlayerPrefsX.SetQuaternion("ObjectRotation" + objectID.ToString(), transform.rotation);

        //PlayerPrefsX.SetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
        //PlayerPrefsX.SetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
           
            gameObject["UserName"] ="User1";
            gameObject["PositionX"] = transform.position.x;
            gameObject["PositionY"] = transform.position.y;
            gameObject["PositionZ"] = transform.position.z;
            gameObject["ObjectName"] = this.gameObject.name;
            gameObject["GameObjectId"] = objectID++;
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject g in gameObjects)
        {
            Debug.Log(g.name);
            if (g.name.ToString().Trim().Contains("Baker_house"))
            {            
                Debug.Log(g.transform.position.x);
            }
        }

            //gameObject["Rotation"] = PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());
            //gameObject["Velocity"] = PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
            //gameObject["AngularVelocity"] = PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
            Task saveTask = gameObject.SaveAsync();
    }
}
