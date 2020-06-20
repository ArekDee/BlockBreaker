using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float pushX;
    [SerializeField] float pushY;
    [SerializeField] float randomFactor;
    [SerializeField] AudioClip[] audioClips;

    Vector3 ballToPaddleVector;
    bool hasStarted = false;
    AudioSource audioSource;
    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
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
            myRigidbody2D.velocity = new Vector2(pushX, pushY);
        }
    }

    void LockBallToPaddle()
    {
        Vector3 paddlePos = new Vector3(paddle.transform.position.x, paddle.transform.position.y, paddle.transform.position.z);
        transform.position = paddlePos + ballToPaddleVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vector = new Vector2(UnityEngine.Random.Range(0f,randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        
        if (hasStarted)
        {
            AudioClip clip = audioClips[UnityEngine.Random.Range(0,audioClips.Length)];
            audioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += vector;
        }
    }
}
