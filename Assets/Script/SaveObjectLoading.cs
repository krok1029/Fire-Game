using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class SaveObjectLoading : MonoBehaviour {
    public GameObject madeObject;
    private int objectID;
    private static int currentObjectID = 0;
    private int n;
   public ArrayList List = new ArrayList();
    
    private int i=0;
    private static int yy = 2;
    public void Start()
    {
       
        objectID = currentObjectID;
        currentObjectID++;
      /*  if (PlayerPrefs.HasKey("Baker_HousePosition" + objectID.ToString()))
        {
            for (n = 0; n < PlayerPrefs.GetInt("ObjectInt_BakerHouse" + objectID.ToString());n++)
            {
               
                Instantiate(madeObject, PlayerPrefsX.GetVector3("Baker_HousePosition" + objectID.ToString()), new Quaternion(-90, 0, 0, 0));

            }

        }
        */

        var query = ParseObject.GetQuery("GameObject").WhereEqualTo("UserName", "user1");
        int xx = 5;
        query.FindAsync().ContinueWith(t =>
        {
            IEnumerable<ParseObject> results = t.Result;
            foreach (var result in results)
            {

                List.Add(result.Get<float>("PositionX"));
                List.Add(result.Get<float>("PositionY"));
                List.Add(result.Get<float>("PositionZ"));

                //x[i] = result.Get<float>("PositionX");
                //y[i] = result.Get<float>("PositionY");
                //z[i] = result.Get<float>("PositionZ");
                //Debug.Log(List[i]);
                i++;

                //Debug.Log("i=" + i);
                
            }
            yy = 1;
        });

        Debug.Log(yy);
        Debug.Log(List.Count);
        for (n = 0; n <i; n++){
            Debug.Log("ok");
            //Instantiate(madeObject, new Vector3(float.Parse(List[n].ToString()),float.Parse(List[n+1].ToString()),float.Parse(List[n+2].ToString())), new Quaternion(-90, 0, 0, 0));
           
            //PlayerPrefsX.SetVector3("ParseBaker_House" + objectID.ToString(), new Vector3(x[i], y[i], z[i]));

        }
    }



}
