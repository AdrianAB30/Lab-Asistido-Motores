using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 angleRotations; 
    [SerializeField] private float rotationSpeed = 50f;

    private void Update()
    {
        QuaternionRotation();
    }
    private void QuaternionRotation()
    {
        Quaternion rotationCoin = Quaternion.Euler(angleRotations * Time.deltaTime * rotationSpeed);
        transform.rotation = transform.rotation * rotationCoin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GainCoin();
            Destroy(gameObject); 
        }
    }
}
