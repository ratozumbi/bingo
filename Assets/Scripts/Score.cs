using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int currBalance = PlayerPrefs.GetInt("total", 0);
        GetComponent<TextMesh>().text = currBalance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
