using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave : MonoBehaviour {
    private  int objectID_baker_house;
    private static int currentObjectID = 0;
    private Rigidbody rb;
    public Button saveButton;
    

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

        objectID_baker_house = currentObjectID;
        currentObjectID++;
        Debug.Log("objectID_baker_house");
        Debug.Log(objectID_baker_house);

        if (PlayerPrefs.HasKey(this.gameObject.name + objectID_baker_house.ToString())){
            transform.position = PlayerPrefsX.GetVector3(this.gameObject.name + objectID_baker_house.ToString());
            transform.rotation = new Quaternion(0,0,0,0);//PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());
            rb.velocity=PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID_baker_house.ToString(), rb.velocity);
            rb.angularVelocity= PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID_baker_house.ToString(), rb.angularVelocity);
            Debug.Log(000000000);
        }


        saveButton.onClick.AddListener(Save);
    }
	
	

    public void Save()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        PlayerPrefsX.SetVector3(this.gameObject.name + objectID_baker_house.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion(this.gameObject.name + objectID_baker_house.ToString(), transform.rotation);

        //PlayerPrefsX.SetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
        //PlayerPrefsX.SetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
           

                gameObject["UserName"] = PlayerPrefs.GetString("UserID");
                gameObject["PositionX"] = this.gameObject.transform.position.x;
                gameObject["PositionY"] = this.gameObject.transform.position.y;
                gameObject["PositionZ"] = this.gameObject.transform.position.z;
                gameObject["ObjectName"] = "Baker_house";
                gameObject["GameObjectId"] = objectID_baker_house;


            //gameObject["Rotation"] = PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());
            //gameObject["Velocity"] = PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
            //gameObject["AngularVelocity"] = PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
            Task saveTask = gameObject.SaveAsync();
    }
}
