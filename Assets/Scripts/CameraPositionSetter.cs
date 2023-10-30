using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionSetter : MonoBehaviour
{

    private Vector3 positionCamera;
    public CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
        positionCamera = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
