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


        if (PlayerPrefs.HasKey("Baker_HousePosition" + objectID_baker_house.ToString())){
            transform.position = PlayerPrefsX.GetVector3("Baker_HousePosition" + objectID_baker_house.ToString());

            transform.rotation =PlayerPrefsX.GetQuaternion("Baker_HouseRotation" + objectID_baker_house.ToString());

        }
        

        saveButton.onClick.AddListener(Save);
    }
	
	

    public void Save()
    {
        

        ParseObject gameObject = new ParseObject("GameObject");
        PlayerPrefsX.SetVector3("Baker_HousePosition" + objectID_baker_house.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion("Baker_HouseRotation" + objectID_baker_house.ToString(), transform.rotation);

        gameObject["UserName"] = PlayerPrefs.GetString("UserID");
        gameObject["PositionX"] = this.gameObject.transform.position.x;
        gameObject["PositionY"] = this.gameObject.transform.position.y;
        gameObject["PositionZ"] = this.gameObject.transform.position.z;

        gameObject["ObjectName"] = this.gameObject.name;
        gameObject["GameObjectId"] = objectID_baker_house;
        Task saveTask = gameObject.SaveAsync();




    }
}
