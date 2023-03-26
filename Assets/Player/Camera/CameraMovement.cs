using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMovement : MonoBehaviour
{
    public float PanSpeed = 30f;
    public float PanBoardThickness = 10f;
    public float ScrollSpeed = 1f;
    public Tilemap PlayableField;
    public float BoundsOffsetMultiplier = 2f;

    private bool doMovement => !GamePauseController.IsPause;
    private float minScrollSize = 2.5f;
    private float maxScrollSize = 15f;
    private Vector2 cameraMovement;
    private Bounds movementBounds;
    // Update is called once per frame

    private void Start()
    {
        movementBounds = PlayableField.localBounds;
        movementBounds.min -= (Vector3)(Vector2.one * BoundsOffsetMultiplier);
        movementBounds.max += (Vector3)(Vector2.one * BoundsOffsetMultiplier);
    }

    void Update()
    {
        if (!doMovement)
            return;

        Movement();
        ChangeCameraSize();
    }

    private void Movement()
    {
        cameraMovement = Vector2.zero;
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - PanBoardThickness)
            cameraMovement += Vector2.up * PanSpeed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= PanBoardThickness)
            cameraMovement += Vector2.down * PanSpeed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - PanBoardThickness)
            cameraMovement += Vector2.right * PanSpeed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= PanBoardThickness)
            cameraMovement += Vector2.left * PanSpeed * Time.fixedDeltaTime;      

        transform.Translate(cameraMovement, Space.World);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, movementBounds.min.x, movementBounds.max.x), 
            Mathf.Clamp(transform.position.y, movementBounds.min.y, movementBounds.max.y), transform.position.z);
    }

    private void ChangeCameraSize()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * ScrollSpeed * Time.fixedDeltaTime, minScrollSize, maxScrollSize);
    }
}
