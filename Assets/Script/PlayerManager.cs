using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    // Use this for initialization


   
    public GameObject Player;                // The enemy prefab to be spawned.
    float spawnTime;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    int number = 0;
    int i = 0;
    int officenum;
    int vendernum;
    GameObject off;
    GameObject ven;
    GameObject clone;
    GameObject[] Players=new GameObject[5];
    ArrayList players = new ArrayList();

    void Awake()
    {
        off = GameObject.Find("Baker_house ");
        ven = GameObject.Find("Fire_Hydrant");
    }

    public void Start()
    {


        InvokeRepeating("Spawn", 2f, 0.2f);

        //Invoke ("Spawn", 5f);
        //Invoke ("Spawn", 10f);
    }

    void Update()
    {

        officenum = off.GetComponent<BuildObject_BakerHouse>().officecounter;
        vendernum = ven.GetComponent<BuildObject_FireHydrant>().vendercounter;
        number = (2* officenum) + (1 * vendernum);
        // Debug.Log("number=" + number);

        //Debug.Log (number);
        //number=3*( GameObject.Find("Main Camera").GetComponent<NowLevel>().level);
    }


    void Spawn()
    {
        //Debug.Log("SPawn");
        // If the player has no health left...
        if (i >= number)
        {
            CancelInvoke("Spawn");
        }

        else
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Players=GameObject.FindGameObjectsWithTag("Man");
            int random=Random.Range(0,4);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            clone = Instantiate(Players[random], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
            i++;
        }
    }



}



































