using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeObject : MonoBehaviour
{
    [SerializeField] private ColorShapeData shapeData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public static Action<Sprite> OnChangeShape;  

    private void SetUp()
    {
        spriteRenderer.sprite = shapeData.sprite;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnChangeShape?.Invoke(shapeData.sprite);
            Debug.Log("Cambiando de forma al player");
        }
    }
}
