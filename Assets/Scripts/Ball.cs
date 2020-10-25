using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private int myIndex;
    private int myNumber;

    private SpriteRenderer myReneder;
    
    // Start is called before the first frame update
    void Start()
    {
        myReneder = GetComponent<SpriteRenderer>();
        myIndex = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckShow(int number, int drawnIndex)
    {
        if (drawnIndex == myIndex)
        {
            myReneder.sprite = Resources.Load<Sprite>("Images/ballsSmall/ballSmall_" + number);
        }
    }
}
