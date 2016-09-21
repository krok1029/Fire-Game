using UnityEngine;
using System.Collections;

public class MoneyCounting : MonoBehaviour {
    PlayerMoney moneya;
    NowLevel moneyGet;
    bool n = false;
    void Start() {
        moneya = GameObject.Find("Main Camera").GetComponent<PlayerMoney>();
        moneyGet= GameObject.Find("Main Camera").GetComponent<NowLevel>();
        
    }
    void Update() {        
        if ( n==false &&moneyGet.totaltime > 0)
        {
            moneya.money += moneyGet.totaltime / 1; //把存檔到下次打開的錢算出來加上去
            n = true;
        }
        if (moneya.money > 100000) { moneya.money = 99999; }
    }
}
