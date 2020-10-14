using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController.PlayerType type;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float sensitivity = 10f;
    [SerializeField] private float maxYAngle = 80f;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gun;

    [SerializeField] private float zoomFieldOfView = 30;
    [SerializeField] private Camera cameraMain;

    private float startFieldOfView;
    private Vector2 currentRotation;

    private void Start()
    {
        startFieldOfView = cameraMain.fieldOfView;
    }

    private void OnEnable()
    {
        InputController.OnMoveInput += MovementLogic;
    }

    private void OnDisable()
    {
        InputController.OnMoveInput += MovementLogic;
    }

    private void Zoom()
    {
        cameraMain.fieldOfView = Input.GetMouseButton(1)
            ? Mathf.Lerp(zoomFieldOfView, startFieldOfView, speed * Time.deltaTime)
            : Mathf.Lerp(startFieldOfView, zoomFieldOfView, speed * Time.deltaTime);
    }

    private void Update()
    {
        Rotate();
        Zoom();
    }


    private void Rotate()
    {
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        cameraMain.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        gun.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        player.transform.rotation = Quaternion.Euler(0, currentRotation.x, 0);
    }

    private void MovementLogic(string horiz, string vert, InputController.PlayerType type)
    {
        if (this.type != type)
            return;

        var moveHorizontal = Input.GetAxis(horiz);
        var moveVertical = Input.GetAxis(vert);
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}