using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] GameObject _object;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _object.transform.position + new Vector3(0f, 1f , transform.position.z); 
    }
}
