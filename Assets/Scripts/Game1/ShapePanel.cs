using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapePanel : MonoBehaviour
{
    [SerializeField] private Image shapeImage;

    private void OnEnable()
    {
        ShapeObject.OnChangeShape += UpdateShape;
    }
    private void OnDisable()
    {
        ShapeObject.OnChangeShape -= UpdateShape;
    }
    public void UpdateShape(Sprite newShape)
    {
        shapeImage.sprite = newShape;
    }
}
