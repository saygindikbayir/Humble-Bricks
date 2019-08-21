using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Button NextLvlButton;
    [HideInInspector]
    public List<BallMovement> Balls = new List<BallMovement>();
    public float CubeRadius;
    public float BallRadius;
    public GameObject Particles;
    public AudioSource pop;
    public GameObject Boost;
    public List<GameObject> Cubes = new List<GameObject>();

    public int CubeCount
    {
        get
        {
            //küp sayısı aktif olanlar
            return Cubes.Where(x => x.activeSelf).ToArray().Length;
        }
    }

    [Space(10)]
    [Header("UI")]
    public GameObject GameOverCanvas;
    public GameObject LevelFinishedCanvas;
    public float CollisionCheckFrequency = 0.05f;

    private bool _gameOver = false;
    public int NumberOfBalls
    {
        get
        {
            return Balls.Count;
        }
    }


    private void Start()
    {
        NextLvlButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level 2");
        });
    }

    void Update()
    {
        //her top için 
        foreach (BallMovement ball1 in Balls)
        {
            //her küp için
            for(int i = 0; i < Cubes.Count; i++)
            {
                //küple top arasındaki uzaklık
                float distance = Vector3.Distance(ball1.transform.position, Cubes[i].transform.position);
                //ikisinin yarı çapını kıyaslıyor
                if (distance < CubeRadius + BallRadius)
                {
                    Debug.Log("Collision between " + ball1.name + "and" + Cubes[i].name);
                    // collide
                    CubeDestroyed(Cubes[i]);
                    ball1.Collision(Cubes[i]);

                    // remove cube
                    Cubes.RemoveAt(i);
                    i--;
                }
            }
        }

        if (Balls.Count == 0)
        {
            GameOverCanvas.SetActive(true);
            _gameOver = true;
        }

        if (CubeCount == 0)
        {
            LevelFinishedCanvas.SetActive(true);
            _gameOver = true;
        }
    }

    public void CubeDestroyed(GameObject cube)
    {
        cube.gameObject.SetActive(false);
        ParticleSystem p = Instantiate(Particles, cube.transform.position,cube.transform.rotation).GetComponent<ParticleSystem>();
        p.Play();
        Destroy(p, p.duration);        
        //%40 şansla toplar 30 dan küçükse boost spawn ediyor
        if(Random.Range(0,1f) >= 0.6f && Balls.Count < 30) {
            Instantiate(Boost, cube.transform.position, cube.transform.rotation);
        }
           
    }

    public void AddBall(BallMovement ball)
    {
        Balls.Add(ball);
    }
    
    public void RemoveBall(BallMovement ball)
    {
        ball.gameObject.SetActive(false);
        Balls.Remove(ball);
    }
}
