using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManager : MonoBehaviour
{
    public static PatrolManager Instance
    {
        get { return instance == null ? (instance = FindObjectOfType<PatrolManager>()) : instance; }
    }

    private static PatrolManager instance;

    public GameObject PatrolPointsHolder;

    private Transform[] points;

    void Awake()
    {
        instance = this;
        points = PatrolPointsHolder.GetComponentsInChildren<Transform>();
    }

    public Transform GetPatrolPoint()
    {
        return points[Random.Range(0, points.Length - 1)];
    }
}
