using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;
    public Sprite[] sprites;
    public float time = 0.05f;
    public float repeatRate = 0.05f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimationSprite), time, repeatRate);
    }

    private void AnimationSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
