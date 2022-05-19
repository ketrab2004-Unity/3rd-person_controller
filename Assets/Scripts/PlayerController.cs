using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotSpeed = 100f;

    public Vector3 feetPos = Vector3.down;
    public float feetSize = 1f;

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        
        transform.Translate(0,0,yInput * speed * Time.deltaTime);
        transform.RotateAround(transform.position, transform.up, xInput * rotSpeed * Time.deltaTime);
        
        JumpUpdate();
    }

    void JumpUpdate()
    {
        //bool isGrounded = Physics.OverlapSphere(transform.localToWorldMatrix.MultiplyPoint(feetPos), feetSize);
    }
    
    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        
        Gizmos.DrawSphere(feetPos, feetSize);
    }
    #endif
}
