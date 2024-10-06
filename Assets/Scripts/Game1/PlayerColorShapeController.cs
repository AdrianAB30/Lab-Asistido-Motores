using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorShapeController : MonoBehaviour
{
    [SerializeField] private ColorShapeData playerData;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        ColorObject.OnChangeColor += UpdateColor;
        ShapeObject.OnChangeShape += UpdateShape;
    }
    private void OnDisable()
    {
        ColorObject.OnChangeColor -= UpdateColor;
        ShapeObject.OnChangeShape -= UpdateShape;
    }
    private void Start()
    {
        SetUp();
    }
    private void SetUp()
    {
        spriteRenderer.color = playerData.color;
        spriteRenderer.sprite = playerData.sprite;
    } 
    public void UpdateColor(Color newColor)
    {
        playerData.color = newColor; 
        spriteRenderer.color = newColor;
        Debug.Log("Color actualizado: " + newColor);
    }

    public void UpdateShape(Sprite newSprite)
    {
        playerData.sprite = newSprite; 
        spriteRenderer.sprite = newSprite;
        Debug.Log("Sprite actualizado: " + newSprite.name);
    }
}
