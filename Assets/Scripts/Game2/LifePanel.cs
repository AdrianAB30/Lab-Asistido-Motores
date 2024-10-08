using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text textLife;

    private void OnEnable()
    {
        GameManager.Instance.OnLifeUpdate += OnLifeUpdate;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnLifeUpdate -= OnLifeUpdate;
    }
    private void OnLifeUpdate(int life)
    {
        Debug.Log("Nueva vida: " + life);
        textLife.text = life.ToString();
    }
}
