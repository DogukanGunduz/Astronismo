using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform destination;

    private void Update()
    {
        transform.Rotate(0f, 1 * Time.deltaTime, 9f);
    }

    public Transform GetDestination()
    {
        return destination;
    }
}
