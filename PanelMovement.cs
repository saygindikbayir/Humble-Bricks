using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelMovement : MonoBehaviour
{
    private float _changeInX, _changeInY;
    private Rigidbody _panel;
    //public float MoveSpeed = 100.0f;
    //public float MoveSpeedMultiply = 10f;
    private float _stunning;
    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    private void Start()
    {
        _panel = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            Vector3 touchPos = Camera.main.ScreenToViewportPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
                directionChosen = false;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                direction = Input.touches[0].deltaPosition.normalized;
                //MoveSpeed = Input.touches[0].deltaPosition.magnitude * MoveSpeedMultiply / Input.touches[0].deltaTime;
                _stunning = Mathf.Clamp(transform.position.x + direction.x, -45f, 45f);
                if (direction.x < 0)
                {
                    transform.position = transform.position + new Vector3(direction.x - (GameSettings.MoveSpeed * Time.fixedDeltaTime), 0, 0);
                }
                else if (direction.x > 0)
                {
                    transform.position = transform.position + new Vector3(direction.x + (GameSettings.MoveSpeed * Time.fixedDeltaTime), 0, 0);
                }
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                _panel.velocity = Vector3.zero;
            }

        }
    }
}