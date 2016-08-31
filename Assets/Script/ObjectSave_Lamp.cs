using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave_Lamp : MonoBehaviour
{
    private int objectID_lamp;
    private static int currentObjectID = 0;
    public Button saveButton;
    string userID;
    bool save;
    // Use this for initialization
    void Start()
    {
        save = PlayerPrefsX.GetBool("save"+objectID_lamp);
        userID = PlayerPrefs.GetString("UserID");
        objectID_lamp = currentObjectID;
        currentObjectID++;
        saveButton.onClick.AddListener(Save);
    }



    public void Save()
    {
        if (this.gameObject.name == "Lamp(Clone)") {
            StartCoroutine(generateItems());
        }
    }
    IEnumerator generateItems()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName",userID).WhereEqualTo("ObjectName", "Lamp").WhereEqualTo("GameObjectId", objectID_lamp);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result["UserName"] = PlayerPrefs.GetString("UserID");
            result["PositionX"] = this.gameObject.transform.position.x;
            result["PositionY"] = this.gameObject.transform.position.y;
            result["PositionZ"] = this.gameObject.transform.position.z;
            result["ObjectName"] = "Lamp";
            result["GameObjectId"] = objectID_lamp;
            Task saveTask2 = result.SaveAsync();
            save = true;
            PlayerPrefsX.SetBool("save"+objectID_lamp, true);
        }
        if (save == false)
        {
            gameObject["UserName"] = PlayerPrefs.GetString("UserID");
            gameObject["PositionX"] = this.gameObject.transform.position.x;
            gameObject["PositionY"] = this.gameObject.transform.position.y;
            gameObject["PositionZ"] = this.gameObject.transform.position.z;
            gameObject["ObjectName"] = "Lamp";
            gameObject["GameObjectId"] = objectID_lamp;
            Task saveTask = gameObject.SaveAsync();
        }
    }
}
