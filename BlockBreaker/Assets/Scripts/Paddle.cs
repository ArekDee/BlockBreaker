using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseCurrentPos = Input.mousePosition.x / Screen.width * 16;
        Vector3 PaddlePos = new Vector3(transform.position.x, transform.position.y,transform.position.z);
        PaddlePos.x = Mathf.Clamp(MouseCurrentPos, minX, maxX);
        transform.position = PaddlePos;
    }
}
