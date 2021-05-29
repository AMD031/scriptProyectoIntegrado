using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraFijada : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public float cameraSlack;
    public float cameraDistance;

    private Vector3 pivotPoint;

    void Start()
    {
        pivotPoint = transform.position;
    }

    void Update()
    {
        Vector3 current = pivotPoint;
        Vector3 target = player.transform.position + Vector3.up;
        pivotPoint = Vector3.MoveTowards(current, target, Vector3.Distance(current, target) * cameraSlack);

        transform.position = pivotPoint;
        transform.LookAt((enemy.position + player.position) / 2);
        transform.position -= transform.forward * cameraDistance;
    }
}