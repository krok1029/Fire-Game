using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SelfSavingTimer : MonoBehaviour
{
    public float time;
    public Text emeryname;
    public Text timerCountDown;
    public Text GameOver;
    public GameObject BackButton;
    public GameObject BackImage;
    void Start()
    {
        time = 30.0f;
    }

    void Update()
    {
        if (emeryname.text.ToString() != "Searching...")
        {

            if (GameObject.Find("Lamp(Clone)") != null || GameObject.Find("Baker_house (Clone)") != null || GameObject.Find("Fire_Hydrant(Clone)") != null)
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    time = 0;
                }


                if (time == 0)
                {
                    GameOver.text = "time's up \n    GameOver!!";
                    BackButton.SetActive(true);
                    BackImage.SetActive(true);
                }

            }
            if (GameObject.Find("Lamp(Clone)") == null && GameObject.Find("Baker_house (Clone)") == null && GameObject.Find("Fire_Hydrant(Clone)") == null && time < 30f)
            {
                GameOver.text = "You Win!!";
                BackButton.SetActive(true);
                BackImage.SetActive(true);
            }
        }
        timerCountDown.text = time.ToString();

    }

}