using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Card : MonoBehaviour
{
    [Tooltip("minus one")]
    public int maxCardNumber = 59;
    
    private List<int> allNumbers = new List<int>();
    
    private List<Cell> cells = new List<Cell>();
    private SpriteRenderer myRenderer;
    
    private List<Prize>allPrizes = new List<Prize>();
    private int myMask;

    void Start()
    {
        FindObjectOfType<Bombo>().drawn.AddListener(CheckMatch);
        
        cells = Transform.FindObjectsOfType<Cell>().ToList();
        cells = cells.OrderBy(c => c.transform.GetSiblingIndex()).ToList();
        
        var numbers = Enumerable.Range(1, maxCardNumber).ToList();
        numbers = numbers.OrderBy(i => Guid.NewGuid()).ToList().GetRange(0, 15);

        allNumbers = numbers.OrderBy(n => n).ToList();
        for (int i =0; i < cells.Count; i++)
        {
            cells[i].Number = allNumbers[i];
        }

        //add prizes
        
        allPrizes.Add(new Prize( 0b111110000000000,100));
        allPrizes.Add(new Prize( 0b000001111100000,100));
        allPrizes.Add(new Prize( 0b000000000011111,100));
        
        allPrizes.Add(new Prize( 0b00100_01010_10001,333));
        
        allPrizes.Add(new Prize( 0b11111_11111_11111,1000));
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Prize prize in allPrizes)
        {
            if(prize.paid == true) continue;
            if ((prize.mask & myMask) == prize.mask)
            {
                print("PRIZE!");
                prize.paid = true;
                int currBalance = PlayerPrefs.GetInt("total", 0);
                currBalance += prize.value;
                PlayerPrefs.SetInt("total",currBalance);

                GameObject.Find("score").GetComponent<TextMesh>().text = currBalance.ToString();

                for (int i = 0; i < cells.Count; i++)
                {
                    if ((prize.mask & (1<<i)) == (1<<i))
                    {
                        if (prize.value == 1000)
                        {
                            cells[i].myType = CellType.Red;
                        }
                        else
                        {
                            cells[i].myType = CellType.Yellow;
                        }
                    }
                }
            }
        }
    }
    
    public void CheckMatch(int number, int drawIndex)
    {
        if (cells.Any(c => c.Number == number))
        {
            
            var currCell =cells.Find(ce => ce.Number == number);
            myMask = myMask | 1<< currCell.transform.GetSiblingIndex();
            currCell.myType = CellType.X;
        }
    }
    
}