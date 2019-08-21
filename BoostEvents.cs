using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoostEvents : MonoBehaviour
{
    public GameObject Boost;
    public GameObject SpherePrefab;
    public int MaxBall = 30;
    private List<Transform> _redBalls= new List<Transform>();
    public GameController Controller;
    
    void Start()
    {
        Controller = FindObjectOfType<GameController>();
    }

    
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallPanel"))
        {
            Destroy(Boost);

            if (Controller.Balls.Count < MaxBall)
            {
                Debug.Log("Boost Activated");
                _redBalls.Clear();
                List<BallMovement> temporary = FindObjectsOfType<BallMovement>().ToList();
                foreach (BallMovement b in temporary)
                {
                    _redBalls.Add(b.transform);
                }

                foreach (Transform redball in _redBalls)
                {
                    //Instantiate(SpherePrefab, new Vector3(redball.position.x - Random.Range(2,5), redball.position.y, redball.position.z), Quaternion.identity);
                    Instantiate(SpherePrefab, new Vector3(redball.position.x + Random.Range(-5, 5), redball.position.y + Random.Range(-5, 5), redball.position.z), Quaternion.identity);
                    //Instantiate(SpherePrefab, new Vector3(redball.position.x, redball.position.y + Random.Range(2, 5), redball.position.z), Quaternion.identity);
                }
            }        
        }
    }
}