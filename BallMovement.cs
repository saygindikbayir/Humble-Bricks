using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public Button BtnLaunch;
    public Transform Ball;
    [Range(1.0f, 50.0f)]
    public float BallSpeed = 5.0f;
    private Vector3 _direction;
    private bool _firstHit = true;
    private bool _isMoving = false;
    private bool _upperArea = false;

    [SerializeField]
    private GameController _gameController;
    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
        _gameController.AddBall(this);
    }
    void Start()
    {
        
        if (BtnLaunch != null)
        {
            BtnLaunch.onClick.AddListener(() => { Launch(); BtnLaunch.gameObject.SetActive(false); });

        }
        else
        {
            Launch();
        }
        //BtnLaunch.onClick.AddListener(() => { Launch(); BtnLaunch.gameObject.SetActive(false);});
        _direction = Vector3.up;

    }

    public void Launch()
    {
        _isMoving = true;
    }

    void FixedUpdate()
    {


        if (_isMoving)
        {
            Ball.transform.Translate(_direction * BallSpeed * Time.fixedDeltaTime, Space.World);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallTop"))
        {
            _direction.y = Vector3.down.y;
            if (_firstHit)
            {
                _direction.x = Vector3.right.x;
                _firstHit = false;
            }

        }
        else if (other.CompareTag("WallPanel"))
        {
            _direction.y = Vector3.up.y;
        }
        else if (other.CompareTag("Wall"))
        {

            if (other.transform.position.x >= transform.position.x)
            {
                _direction.x = Vector3.left.x;
            }
            else
            {
                _direction.x = Vector3.right.x;
            }

        }
        
        else if (other.CompareTag("WallBottom"))
        {
            Debug.Log("Event System Counter = " + _gameController.NumberOfBalls);
            _gameController.RemoveBall(this);
        }
        
        _direction.Normalize();
    }

    public void Collision(GameObject other)
    {
        _upperArea = transform.position.y > other.transform.position.y;
        Vector3 localBallPos = other.transform.InverseTransformPoint(transform.position);
        Vector3 rightVector = new Vector3(localBallPos.x, 0, other.transform.localPosition.z);

        float angle = AngleInDeg(rightVector, localBallPos);

        if(_upperArea)
        {
            //deneme kodudur.
            //if (_firstHit)
            //{
            //    _direction.x = Vector3.right.x;
            //    _firstHit = false;
            //}
            //deneme kodunun bitimidir
            if(angle < 45)
            {
                _direction.x = Vector3.left.x;
            }
            else if(angle < 135)
            {
                _direction.y = Vector3.up.y;
            }
            else
            {
                _direction.x = Vector3.left.x;
            }
        }
        else
        {
            if (angle < 45)
            {
                _direction.x = Vector3.right.x;
            }
            else if (angle < 135)
            {
                _direction.y = Vector3.down.y;
            }
            else
            {
                _direction.x = Vector3.left.x;
            }
        }
        Debug.Log("right vector: " + rightVector);
        Debug.Log("ball pos: " + localBallPos);
        Debug.Log("angle: " + angle);
    }


    public static float AngleInDeg(Vector2 from, Vector2 to)
    {        
        float a = from.x;
        float c = Mathf.Sqrt(Mathf.Pow(from.x, 2) + Mathf.Pow(to.y, 2));
        Debug.Log("a: " + a);
        Debug.Log("c: " + c);
        Debug.Log("a / c : " + a / c);
        float angle = Mathf.Acos(a / c);
        return angle * 180 / Mathf.PI;
    }

}
