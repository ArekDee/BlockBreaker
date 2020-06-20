using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject blockSparkles;

    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;
    int maxHits;
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        maxHits = hitSprites.Length;
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
        gameStatus = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            timesHit++;
            
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit];
    }

    void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        TrigerSparkles();
        Destroy(gameObject);
        level.BlockDestroyed();
        gameStatus.AddToScore();
    }

    void TrigerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparkles,transform.position,transform.rotation);
        Destroy(sparkles, 2f);
    }
}
