using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave_FireHydrant : MonoBehaviour{
    private  int objectID_firehydrant;
    private static int currentObjectID = 0;
    private Rigidbody rb;
    public Button saveButton;
    public GameObject firehydrant;


    // Use this for initialization
    void Start(){

        rb = GetComponent<Rigidbody>();

        objectID_firehydrant = currentObjectID;
        
        currentObjectID++;
        if (PlayerPrefs.HasKey("FireHydrantPosition" + objectID_firehydrant.ToString()))
        {
            transform.position = PlayerPrefsX.GetVector3("FireHydrantPosition" + objectID_firehydrant.ToString());
            transform.rotation = PlayerPrefsX.GetQuaternion("FireHydrantRosition" + objectID_firehydrant.ToString());


        }

        saveButton.onClick.AddListener(Save);
    }



    public void Save()
    {

 


        ParseObject gameObject = new ParseObject("GameObject");
        PlayerPrefsX.SetVector3("FireHydrantPosition" + objectID_firehydrant.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion("FireHydrantRosition" + objectID_firehydrant.ToString(), transform.rotation);

                gameObject["UserName"] = PlayerPrefs.GetString("UserID");
                gameObject["PositionX"] = this.gameObject.transform.position.x;
                gameObject["PositionY"] = this.gameObject.transform.position.y;
                gameObject["PositionZ"] = this.gameObject.transform.position.z;
                gameObject["ObjectName"] = this.gameObject.name;
                gameObject["GameObjectId"] = objectID_firehydrant;

        Task saveTask = gameObject.SaveAsync();
    }
}
