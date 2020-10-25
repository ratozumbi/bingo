using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CellType
{
    Red,Yellow,X,Blank
}
public class Cell : MonoBehaviour
{

    
    private SpriteRenderer spriteRenderer;
    
    private List<Sprite> allCellSprites = new List<Sprite>();
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
            GetComponent<SpriteRenderer>().sprite = allCellSprites[(int)_myType];
        }
    }

    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            GetComponentInChildren<TextMesh>().text = (_number+1).ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Sprite[] cellImages = Resources.LoadAll <Sprite> ("Images/cell");  
        allCellSprites.AddRange(cellImages);
        myType = CellType.Blank;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
