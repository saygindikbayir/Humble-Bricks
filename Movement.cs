using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //variables
    public float moveSpeed = 1;
    public GameObject character;

    private Rigidbody characterBody;
    private float ScreenWidth;
    


    // Use this for initialization
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        int i = 0;
        
        while (i < Input.touchCount)
        {   //sağ
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                
                MovePallet(1.0f);
            }
            //sol
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                
                MovePallet(-1.0f);
            }
            ++i;
        }
    }
    void FixedUpdate()
    {
#if UNITY_EDITOR
        MovePallet(Input.GetAxis("Horizontal"));
#endif
    }

    private void MovePallet(float horizontalInput)
    {
        //move player
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
       // characterBody.MovePosition(new Vector3(characterBody.transform.position.x + horizontalInput * moveSpeed * Time.deltaTime, characterBody.transform.position.y, characterBody.transform.position.z));

    }
   
   
   
}