using UnityEngine;
using System.Collections;
using Cinemachine;

public class CameraPan : MonoBehaviour
{

    public float speed = 0.017F;
    float height;
    float width;
    float rightPosition;
    float leftPosition;
    private Vector3 positionCamera;
    public CinemachineVirtualCamera camerax;


    private void Start()
    {
        
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        rightPosition = GameObject.FindGameObjectWithTag("rightPosition").transform.position.x;
        leftPosition = GameObject.FindGameObjectWithTag("leftPosition").transform.position.x;
        camerax = GetComponent<CinemachineVirtualCamera>();
        positionCamera = camerax.transform.position;
        positionCamera.x= leftPosition;
        camerax.transform.position = positionCamera;
    }
    private Vector3 ClampCamera(Vector2 targetPosition)
    {
        float minPosition = leftPosition + width /2f;
        float maxPosition = rightPosition - width / 2f;

        float newX = Mathf.Clamp(targetPosition.x, minPosition, maxPosition);

        return new Vector3(newX, targetPosition.y, transform.position.z);
    }
    void Update()
    {
        transform.position = ClampCamera(transform.position);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, 0, 0);
        }
    }
}
