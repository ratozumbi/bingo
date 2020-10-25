﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CellType
{
    Red,Yellow,X,Blank
}
public class Cell : MonoBehaviour
{

    
    private SpriteRenderer spriteRenderer;
    
    public List<Sprite> dictCells = new List<Sprite>();
    private int _number;
    private CellType _myType;
    public CellType myType
    {
        get
        {
            return _myType;
        }
        set
        {
            _myType = value;
            GetComponent<SpriteRenderer>().sprite = dictCells[(int)_myType];
        }
    }

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
        Sprite[] cellImages = Resources.LoadAll <Sprite> ("Images/cell");  
        dictCells.AddRange(cellImages);
        myType = CellType.Red;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}