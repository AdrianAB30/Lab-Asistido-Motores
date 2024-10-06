using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private ColorShapeData colorData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public static Action<Color> OnChangeColor; 

    private void SetUp()
    {
        spriteRenderer.color = colorData.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnChangeColor?.Invoke(colorData.color);
            Debug.Log("Cambiando de color al player");

        }
    }
}
