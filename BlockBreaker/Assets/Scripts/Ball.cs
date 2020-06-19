using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float pushX;
    [SerializeField] float pushY;
    [SerializeField] AudioClip[] audioClips;

    Vector3 ballToPaddleVector;
    bool hasStarted = false;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LanchOnClick();
        }
        

        
    }

    private void LanchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(pushX, pushY);
        }
    }

    void LockBallToPaddle()
    {
        Vector3 paddlePos = new Vector3(paddle.transform.position.x, paddle.transform.position.y, paddle.transform.position.z);
        transform.position = paddlePos + ballToPaddleVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = audioClips[UnityEngine.Random.Range(0,audioClips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
