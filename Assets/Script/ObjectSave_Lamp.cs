using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave_Lamp : MonoBehaviour
{
    private static int objectID;
    private static int currentObjectID = 0;
    private int ID;
    private Rigidbody rb;
    public Button saveButton;


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        objectID = currentObjectID;
        currentObjectID++;
        if (PlayerPrefs.HasKey(this.gameObject.name + objectID.ToString()))
        {
            transform.position = PlayerPrefsX.GetVector3(this.gameObject.name + objectID.ToString());
            transform.rotation = new Quaternion(0, 0, 0, 0);//PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());
            rb.velocity = PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
            rb.angularVelocity = PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
            Debug.Log(000000000);
        }


        saveButton.onClick.AddListener(Save);
    }



    public void Save()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        PlayerPrefsX.SetVector3(this.gameObject.name + objectID.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion(this.gameObject.name + objectID.ToString(), transform.rotation);

        //PlayerPrefsX.SetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
        //PlayerPrefsX.SetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);


        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject g in gameObjects)
        {
            // Debug.Log(g.name);
            if (g.name.ToString().Trim().Contains("Baker_house"))
            {
                gameObject["UserName"] = PlayerPrefs.GetString("UserID");
                gameObject["PositionX"] = this.gameObject.transform.position.x;
                gameObject["PositionY"] = this.gameObject.transform.position.y;
                gameObject["PositionZ"] = this.gameObject.transform.position.z;
                gameObject["ObjectName"] = this.gameObject.name;
                gameObject["GameObjectId"] = objectID;
            }
        }

        //gameObject["Rotation"] = PlayerPrefsX.GetQuaternion("ObjectRotation" + objectID.ToString());
        //gameObject["Velocity"] = PlayerPrefsX.GetVector3("ObjectRigidbodyVelocity" + objectID.ToString(), rb.velocity);
        //gameObject["AngularVelocity"] = PlayerPrefsX.GetVector3("ObjectRigidbodyAngularVelocity" + objectID.ToString(), rb.angularVelocity);
        Task saveTask = gameObject.SaveAsync();
    }
}
