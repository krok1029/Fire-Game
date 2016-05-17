using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave_Lamp : MonoBehaviour
{
    private int objectID_lamp;
    private static int currentObjectID = 0;
    private int ID;
    private Rigidbody rb;
    public Button saveButton;
    
    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        objectID_lamp = currentObjectID;
        currentObjectID++;
        if (PlayerPrefs.HasKey("LampPosition" + objectID_lamp.ToString()))
        {
            transform.position = PlayerPrefsX.GetVector3("LampPosition" + objectID_lamp.ToString());
            transform.rotation = PlayerPrefsX.GetQuaternion("LampRosition" + objectID_lamp.ToString());


        }


        saveButton.onClick.AddListener(Save);
    }



    public void Save()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        PlayerPrefsX.SetVector3("LampPosition" + objectID_lamp.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion("LamRosition" + objectID_lamp.ToString(), transform.rotation);





                gameObject["UserName"] = PlayerPrefs.GetString("UserID");
                gameObject["PositionX"] = this.gameObject.transform.position.x;
                gameObject["PositionY"] = this.gameObject.transform.position.y;
                gameObject["PositionZ"] = this.gameObject.transform.position.z;
                gameObject["ObjectName"] = "Lamp";
                gameObject["GameObjectId"] = objectID_lamp;


        Task saveTask = gameObject.SaveAsync();
    }
}
