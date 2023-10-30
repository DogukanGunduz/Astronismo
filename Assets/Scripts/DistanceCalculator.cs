using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] Transform gate;
    public float distance;

    private void Start()
    {
        distance = (gate.transform.position.x - transform.position.x);
    }
    void FixedUpdate ()
    {
        distance = (gate.transform.position.x - transform.position.x);
    }
}
