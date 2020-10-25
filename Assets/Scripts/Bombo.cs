using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DrawnEvent : UnityEvent<int,int>
{
    
}
public class Bombo : MonoBehaviour
{
    public DrawnEvent drawn;

    private List<int> allNumbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        var numbers = Enumerable.Range(1, 90).ToList();
        allNumbers = numbers.OrderBy(i => Guid.NewGuid()).ToList().GetRange(0, 15);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawnBall()
    {
        drawn.Invoke(1,1);
    }
    
}
