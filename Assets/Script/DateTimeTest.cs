using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using Parse;




public class DateTimeTest : MonoBehaviour
{

    public Text dateTimeText;
    void Update()
    {
        dateTimeText.text = DateTime.Now.ToString();
    }


}
