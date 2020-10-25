using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    private int _number;

    public int Number
    {
        get => _number;
        set
        {
            GetComponentInChildren<TextMesh>().text = value.ToString();
            _number = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
