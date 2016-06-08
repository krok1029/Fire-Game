using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave : MonoBehaviour {
    private int objectID_baker_house;
    private static int currentObjectID = 0;
    int c=0;
    public Button saveButton;
    string userID;


    // Use this for initialization
    void Start() {
        userID = PlayerPrefs.GetString("UserID");
        objectID_baker_house = currentObjectID;
        currentObjectID++;
        if (PlayerPrefs.HasKey("Baker_HousePosition" + objectID_baker_house.ToString()))
        {
            transform.position = PlayerPrefsX.GetVector3("Baker_HousePosition" + objectID_baker_house.ToString());
            transform.rotation = PlayerPrefsX.GetQuaternion("Baker_HouseRotation" + objectID_baker_house.ToString());
        }
        saveButton.onClick.AddListener(Save);
    }
    
    public void Save()
    {

        PlayerPrefsX.SetVector3("Baker_HousePosition" + objectID_baker_house.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion("Baker_HouseRotation" + objectID_baker_house.ToString(), transform.rotation);
     if (this.gameObject.name == "Baker_house (Clone)")///原本的不會存
        {
            StartCoroutine(generateItems());//更新
        }

    }
    IEnumerator generateItems()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", userID).WhereEqualTo("ObjectName", "Baker_house");
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result.DeleteAsync();
            
        }
        
        gameObject["UserName"] = PlayerPrefs.GetString("UserID");
        gameObject["PositionX"] = this.gameObject.transform.position.x;
        gameObject["PositionY"] = this.gameObject.transform.position.y;
        gameObject["PositionZ"] = this.gameObject.transform.position.z;
        gameObject["ObjectName"] = "Baker_house";
        gameObject["GameObjectId"] = objectID_baker_house;
        Task saveTask = gameObject.SaveAsync();

    }
}
