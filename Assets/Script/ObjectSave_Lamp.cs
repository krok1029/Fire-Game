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

    // Use this for initialization
    void Start()
    {
        

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
        PlayerPrefsX.SetVector3("LampPosition" + objectID_lamp.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion("LamRosition" + objectID_lamp.ToString(), transform.rotation);
        if (this.gameObject.name == "Lamp(Clone)") {
            StartCoroutine(generateItems());
        }
    }
    IEnumerator generateItems()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", "user1").WhereEqualTo("ObjectName", "Lamp");
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
        gameObject["ObjectName"] = "Lamp";
        gameObject["GameObjectId"] = objectID_lamp;
        Task saveTask = gameObject.SaveAsync();

    }
}
