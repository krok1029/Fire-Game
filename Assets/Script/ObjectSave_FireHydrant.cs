using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ObjectSave_FireHydrant : MonoBehaviour{
    private  int objectID_firehydrant;
    private static int currentObjectID = 0;

    public Button saveButton;
    public GameObject firehydrant;


    // Use this for initialization
    void Start(){



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
        PlayerPrefsX.SetVector3("FireHydrantPosition" + objectID_firehydrant.ToString(), transform.position);
        PlayerPrefsX.SetQuaternion("FireHydrantRosition" + objectID_firehydrant.ToString(), transform.rotation);
        
        if (this.gameObject.name == "Fire_Hydrant(Clone)")
        {
            StartCoroutine(generateItems());//更新
        }
    }
    IEnumerator generateItems()
    {
        ParseObject gameObject = new ParseObject("GameObject");
        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", "user1").WhereEqualTo("ObjectName", "Fire_Hydrant");
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
        gameObject["ObjectName"] = "Fire_Hydrant";
        gameObject["GameObjectId"] = objectID_firehydrant;
        Task saveTask = gameObject.SaveAsync();

    }
}
