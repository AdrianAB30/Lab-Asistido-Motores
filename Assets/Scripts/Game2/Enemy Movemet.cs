using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemet : MonoBehaviour
{
    [SerializeField] private Transform[] pivotPoints;
    private Rigidbody myRBD;
    private int currentPatrolIndex = 0;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float distance = 0.1f;

    private void Awake()
    {
        myRBD = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if(pivotPoints.Length == 0)
        {
            return;
        }
        Transform targetPoint = pivotPoints[currentPatrolIndex];
        Vector3 target = targetPoint.position;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < distance)
        {
            UpdatePoint();
        }
    }
    private void UpdatePoint()
    {
        if(pivotPoints.Length == 0)
        {
            return;
        }
        currentPatrolIndex = (currentPatrolIndex + 1) % pivotPoints.Length;
    }
}
