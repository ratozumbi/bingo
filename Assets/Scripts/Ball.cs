using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private int myIndex;
    private int myNumber;

    private SpriteRenderer myRenederer;
    private List<Sprite> allNumbers = new List<Sprite>();
    
    // Start is called before the first frame update
    void Start()
    {
        Sprite[] ballImages = Resources.LoadAll <Sprite> ("Images/ballsSmall");  
        allNumbers.AddRange(ballImages);
        
        myRenederer = GetComponent<SpriteRenderer>();
        myIndex = transform.GetSiblingIndex();

        FindObjectOfType<Bombo>().drawn.AddListener(CheckShow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckShow(int number, int drawIndex)
    {
        if (drawIndex == myIndex)
        {
            myRenederer.sprite = allNumbers[number];
            myRenederer.color =Color.white;
        }
    }
}
