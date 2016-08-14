using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave : MonoBehaviour {
    private int objectID_baker_house;
    private static int currentObjectID = 0;
    public Button saveButton;
    string userID;
    bool save ;

    // Use this for initialization
    void Start()
    {
        save=PlayerPrefsX.GetBool("save");
        userID = PlayerPrefs.GetString("UserID");
        objectID_baker_house = currentObjectID;
        currentObjectID++;
        saveButton.onClick.AddListener(Save);
    }
    
    public void Save()
    {
        if (this.gameObject.name == "Baker_house (Clone)")///原本的不會存
        {
              StartCoroutine(generateItems());//更新

        }

    }
    IEnumerator generateItems()
    {     
        ParseObject gameObject = new ParseObject("GameObject");
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", userID).WhereEqualTo("ObjectName", "Baker_house").WhereEqualTo("GameObjectId", objectID_baker_house);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result["UserName"] = PlayerPrefs.GetString("UserID");
            result["PositionX"] = this.gameObject.transform.position.x;
            result["PositionY"] = this.gameObject.transform.position.y;
            result["PositionZ"] = this.gameObject.transform.position.z;
            result["ObjectName"] = "Baker_house";
            result["GameObjectId"] = objectID_baker_house;
            Task saveTask2 = result.SaveAsync();
            save = true;
            PlayerPrefsX.SetBool("save", true);
        }
        if (save == false)
        {
            gameObject["UserName"] = PlayerPrefs.GetString("UserID");
            gameObject["PositionX"] = this.gameObject.transform.position.x;
            gameObject["PositionY"] = this.gameObject.transform.position.y;
            gameObject["PositionZ"] = this.gameObject.transform.position.z;
            gameObject["ObjectName"] = "Baker_house";
            gameObject["GameObjectId"] = objectID_baker_house;
            Task saveTask = gameObject.SaveAsync();
        }

    } 
}
