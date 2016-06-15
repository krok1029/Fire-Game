using UnityEngine;
using System.Collections;
using Parse;
using System.Threading.Tasks;

public class userCounter : MonoBehaviour {
    public int counter;

	// Use this for initialization
	void Start () {
        Debug.Log("OK!!");
        StartCoroutine(generateItems());
    }
    IEnumerator generateItems()
    {
        ParseObject gameObject = new ParseObject("User");
        var query = ParseObject.GetQuery("User");
        var task = query.FindAsync();
        while (!task.IsCompleted) yield return null;
        foreach (var result in task.Result)
        {
            counter = counter + 1;
        }
        Debug.Log("counter="+counter);
    }
}
