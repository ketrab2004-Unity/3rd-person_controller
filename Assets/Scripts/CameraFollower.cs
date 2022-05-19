using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    
    public Vector3 offset;
    public Quaternion rotation;

    public float zoom = 1;
    public float zoomSpeed = .1f;
    public Vector2 zoomRange = new Vector2(.5f, 5f);
    
    void Start()
    {
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollDelta = Input.mouseScrollDelta.y;
        zoom -= scrollDelta * zoomSpeed * zoom; //* zoom to zoom faster when zoomed out
        zoom = Math.Min(Math.Max(zoom, zoomRange.x), zoomRange.y); //clamp

        //camera positioning
        transform.rotation = target.rotation * rotation;
        
        transform.position = target.position + transform.rotation * offset * zoom;
    }
}
