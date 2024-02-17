using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    private bool shotFired = false;
    public Vector2 minPower;
    public Vector2 maxPower;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    LineaTraiettoria tl;

    private void Start()
    {
        cam=Camera.main;
        tl = GetComponent<LineaTraiettoria>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)&& !shotFired)
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            Debug.Log(startPoint);
        }
        if(Input.GetMouseButton(0) && !shotFired) { 
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }


        if (Input.GetMouseButtonUp(0) && !shotFired)
        {
            endPoint= cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            Debug.Log(endPoint);
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
            shotFired= true;
        }
        if (shotFired && rb.velocity.magnitude <= 0.01f)
        {
            GameManager.instance.DecreaseLives();
        }
        
    }
    private bool IsGrounded()
    {
        // Raycast downward to check if the ball is grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            return true;
        }
        return false;
    }
}
