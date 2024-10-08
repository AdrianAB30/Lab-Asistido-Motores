using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorPowerUpManager : MonoBehaviour
{
    [SerializeField] private ColorData[] colors;
    [SerializeField] private ColorData currentColor;
    private bool canChangeColor = true;

    public static event Action<ColorData> OnChangeColor;

    private void OnEnable()
    {
        Enemy.OnEnter += ValidateCollision;
        Enemy.OnExit += ReturnToNormal;
    }
    private void OnDisable()
    {
        Enemy.OnEnter -= ValidateCollision;
        Enemy.OnExit -= ReturnToNormal;
    }
    private void Start()
    {
        if (colors != null && colors.Length > 0)
        {
            currentColor = colors[0]; 
            Debug.Log("Color inicial: " + currentColor.color);
        }
        else
        {
            Debug.LogError("No hay colores asignados en el array");
        }
    }
    public void OnPreviousColor(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeColorSelection(-1);
        }
    }
    public void OnNextColor(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeColorSelection(1);
        }
    }
    private void ChangeColorSelection(int direction)
    {
        if (!canChangeColor) 
        {
            return;
        } 
        int currentIndex = Array.IndexOf(colors, currentColor);
        currentIndex += direction;

        if (currentIndex < 0)
        {
            currentIndex = colors.Length - 1;
        }
        else if (currentIndex >= colors.Length) 
        {
            currentIndex = 0;
        }

        currentColor = colors[currentIndex];
        Debug.Log("Nuevo color seleccionado: " + currentColor.color);
        OnChangeColor?.Invoke(currentColor); 
    }

    private void ValidateCollision(ColorData otherColor, int damage)
    {
        if (otherColor.color != currentColor.color)
        {
            GameManager.Instance.ModifyLife(-damage);
            canChangeColor = false; 
        }
    }

    private void ReturnToNormal()
    {
        canChangeColor = true; 
    }
}
