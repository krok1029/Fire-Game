using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave_Water : MonoBehaviour
{
    private int objectID_Water;
    private static int currentObjectID = 0;
    public Button saveButton;
    string userID;
    bool save;

    // Use this for initialization
    void Start()
    {
        save = PlayerPrefsX.GetBool("save");
        userID = PlayerPrefs.GetString("UserID");
        objectID_Water = currentObjectID;
        currentObjectID++;
        saveButton.onClick.AddListener(Save);
    }

    public void Save()
    {
        if (this.gameObject.name == "Water(Clone)")///原本的不會存
        {
            StartCoroutine(generateItems());//更新

        }

    }
    IEnumerator generateItems()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", userID).WhereEqualTo("ObjectName", "Water").WhereEqualTo("GameObjectId", objectID_Water);
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            result["UserName"] = PlayerPrefs.GetString("UserID");
            result["PositionX"] = this.gameObject.transform.position.x;
            result["PositionY"] = this.gameObject.transform.position.y;
            result["PositionZ"] = this.gameObject.transform.position.z;
            result["ObjectName"] = "Water";
            result["GameObjectId"] = objectID_Water;
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
            gameObject["ObjectName"] = "Water";
            gameObject["GameObjectId"] = objectID_Water;
            Task saveTask = gameObject.SaveAsync();
        }

    }
}
