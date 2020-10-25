using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Card : MonoBehaviour
{
    private List<int> allNumbers = new List<int>();
    
    void Start()
    {
        var cells = Transform.FindObjectsOfType<Cell>().ToList();
        cells = cells.OrderBy(c => c.transform.GetSiblingIndex()).ToList();
        
        var numbers = Enumerable.Range(1, 90).ToList();
        numbers = numbers.OrderBy(i => Guid.NewGuid()).ToList().GetRange(0, 15);

        allNumbers = numbers.OrderBy(n => n).ToList();
        for (int i =0; i < cells.Count; i++)
        {
            cells[i].Number = allNumbers[i];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}