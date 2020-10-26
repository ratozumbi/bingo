using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int currBalance = PlayerPrefs.GetInt("total", 0);
        if (currBalance <= 0)//initial credit
        {
            PlayerPrefs.SetInt("total",111);
        }
        GetComponent<TextMesh>().text = currBalance.ToString();
    }

    public void PayToPlay()
    {
        int currBalance = PlayerPrefs.GetInt("total", 0);
        currBalance -= 10;
        PlayerPrefs.SetInt("total", currBalance);
        GetComponent<TextMesh>().text = currBalance.ToString();
    }
}
