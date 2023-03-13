using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float PanSpeed = 30f;
    public float PanBoardThickness = 10f;
    public float ScrollSpeed = 1f;

    private bool doMovement = true;
    private float minScrollSize = 2.5f;
    private float maxScrollSize = 10f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - PanBoardThickness)
        {
            transform.Translate(Vector2.up * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= PanBoardThickness)
        {
            transform.Translate(Vector2.down * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - PanBoardThickness)
        {
            transform.Translate(Vector2.right * PanSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= PanBoardThickness)
        {
            transform.Translate(Vector2.left * PanSpeed * Time.deltaTime, Space.World);
        }

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * ScrollSpeed * Time.deltaTime, minScrollSize, maxScrollSize);
    }
}
