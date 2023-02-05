using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{

    public new UnityEngine.Camera camera;
    [Range(0, 100f)]
    public float moveSpeed = 10f;
    [Range(0f, 100f)]
    public float sensitivity = 3;
    public bool isDragging { get; private set; }
    private bool isZooming = false;


    [Range(0, 15f)]
    public float ZoomMax;
    [Range(0, 15f)]
    public float ZoomMin;
    [Range(0, 0.5f)]
    public float ZoomSensitivity;

    public GameObject ObjectBlockCameratemp;
    public static GameObject ObjectBlockCamera;

    private Vector2 tempCenter, targetDirection, tempMousePos;
    private float tempSens;

    private Vector2 bottomLeft = new Vector2(0, 0);
    private Vector2 Center = new Vector2(960, 540);
    private Vector2 topRight = new Vector2(1920, 1080);

    private Touch touchA;
    private Touch touchB;
    private Vector2 TouchAPoint;
    private Vector2 TouchBPoint;
    private Vector2 touchADirection;
    private Vector2 touchBDirection;
    private float dstBtwTouchesPosition;
    private float dstBtwTouchesDirections;
    private float zoom;

    private void Awake()
    {
        ObjectBlockCamera = ObjectBlockCameratemp;
    }
    public static void BlockCamera()
    {
        if (ObjectBlockCamera.active)
        {
            ObjectBlockCamera.SetActive(false);

        }
        else
        {
            ObjectBlockCamera.SetActive(true);
        }
    }

    void Update()
    {
        if (!ObjectBlockCamera.active)
        {
            if (Input.touchCount == 2)
            {
                UpdateZoom();
            }
            else
            {
                isZooming = false;
                UpdateInput();
                UpdatePosition();
            }
        }

    }


    private void UpdateZoom()
    {

        touchA = Input.GetTouch(0);
        touchB = Input.GetTouch(1);
        Vector2 TouchAPos = touchA.position;
        Vector2 TouchBPos = touchB.position;
        if (!isZooming)
        {
            TouchAPoint = GetWorldPoint(TouchAPos);
            TouchBPoint = GetWorldPoint(TouchBPos);
            isZooming = true;
        }
        
        
        

        touchADirection = TouchAPos - touchA.deltaPosition;
        touchBDirection = TouchBPos - touchB.deltaPosition;
        float TouchCenterX = (TouchAPoint.x + TouchBPoint.x)/2;
        float TouchCenterY = (TouchAPoint.y + TouchBPoint.y) / 2;
        dstBtwTouchesPosition = Vector2.Distance(TouchAPos, TouchBPos);
        dstBtwTouchesDirections = Vector2.Distance(touchADirection, touchBDirection);

        zoom = dstBtwTouchesPosition - dstBtwTouchesDirections;
        //5/1 = 5 
        //5/0.05/100 
        sensitivity = camera.orthographicSize / 5;
        ZoomSensitivity = camera.orthographicSize / 100;
        var currentZoom = camera.orthographicSize - zoom * ZoomSensitivity;

        Vector2 newPosition = new Vector2(TouchCenterX, TouchCenterY);
        Vector2 Position = camera.transform.position;
        camera.transform.position = Vector2.Lerp(Position, newPosition, Time.deltaTime * 15f);
        camera.orthographicSize = Mathf.Clamp(currentZoom, ZoomMin, ZoomMax);
        

    }

    private Vector2 GetWorldPoint(Vector2 mousePosition)
    {
        Vector2 point = Vector2.zero;
        Ray ray = camera.ScreenPointToRay(mousePosition);

        Vector3 normal = Vector3.forward;
        Vector3 position = Vector3.zero;
        Plane plane = new Plane(normal, position);

        plane.Raycast(ray, out float distance);
        point = ray.GetPoint(distance);

        return point;
    }
    private void UpdateInput()
    {
            
        Vector2 mousePosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0)) OnPointDown(mousePosition);
        else if (Input.GetMouseButtonUp(0)) OnPointUp(mousePosition);
        else if (Input.GetMouseButton(0)) OnPointMove(mousePosition);
    }
    private void UpdatePosition()
    {
        float speed = Time.deltaTime * moveSpeed;
        if (isDragging) tempSens = sensitivity;
        else tempSens = Mathf.Lerp(tempSens, 0f, speed);

        Vector2 newPosition = transform.position + (Vector3)targetDirection * tempSens;


        topRight = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth, camera.pixelHeight));
        Center = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2));
        bottomLeft = camera.ScreenToWorldPoint(new Vector2(0, 0));

        if ((bottomLeft.x < -9f))
        {
            float distance = Center.x - bottomLeft.x;
            newPosition.x = -9f + distance + 0.1f;
        }
        else if (topRight.x > 30f)
        {
            float distance = topRight.x - Center.x;
            newPosition.x = 30f - distance - 0.1f;
        }
        if ((bottomLeft.y < -5f))
        {
            float distance = Center.y - bottomLeft.y;
            newPosition.y = -5f + distance + 0.1f;
        }
        else if (topRight.y > 15f)
        {
            float distance = topRight.y - Center.y;
            newPosition.y = 15f - distance - 0.1f;
        }


        Vector2 Position = camera.transform.position;
        transform.position = Vector2.Lerp(Position, newPosition, speed);
    }
    private void OnPointDown(Vector2 mousePosition)
    {
        tempCenter = GetWorldPoint(mousePosition);
        targetDirection = Vector2.zero;
        tempMousePos = mousePosition;
        isDragging = true;
    }
    private void OnPointMove(Vector2 mousePosition)
    {
        if (isDragging)
        {
            Vector2 point = GetWorldPoint(mousePosition);
            float sqrDist = (tempCenter - point).sqrMagnitude;
            if (sqrDist > 0.1f * sensitivity)
            {
                targetDirection = (tempMousePos - mousePosition).normalized;
                tempMousePos = mousePosition;

            }
        }
    }
    private void OnPointUp(Vector2 mousePosition)
    {
        isDragging = false;
    }
}
