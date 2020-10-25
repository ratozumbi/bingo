﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DrawnEvent : UnityEvent<int,int> // ball number , draft index
{
    
}
public class Bombo : MonoBehaviour
{
    public DrawnEvent drawn;
    
    public int maxBallNumber = 30;
    
    private int maxBalls = 30;
    private List<int> allNumbers = new List<int>();
    private int drawnIndex = 0;
    private SpriteRenderer myRenderer;
    private List<Sprite> allSpriteNumbers = new List<Sprite>();
    
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        
        Sprite[] ballImages = Resources.LoadAll <Sprite> ("Images/ballsBig");  
        allSpriteNumbers.AddRange(ballImages);
        
        var numbers = Enumerable.Range(0, maxBallNumber).ToList();
        allNumbers = numbers.OrderBy(i => Guid.NewGuid()).ToList().GetRange(0, maxBalls);
        

    }

    // Update is called once per frame
    void Update()
    {
        DrawBall();
    }

    private void DrawBall()
    {
        if (drawnIndex >= maxBalls) return;
        myRenderer.sprite = allSpriteNumbers[allNumbers[drawnIndex]];
        drawn.Invoke(allNumbers[drawnIndex],drawnIndex);
        drawnIndex++;
    }
    
}
