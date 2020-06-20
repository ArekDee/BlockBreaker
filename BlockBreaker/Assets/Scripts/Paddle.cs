﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameStatus gameStatus;
    Ball ball;
    

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 PaddlePos = new Vector3(transform.position.x, transform.position.y,transform.position.z);
        PaddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = PaddlePos;
    }

    float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * 16;
        }
    }
}
