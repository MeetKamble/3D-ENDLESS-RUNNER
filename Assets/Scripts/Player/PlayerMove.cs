using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float leftRightSpeed = 4.0f;
    static public bool canMove = false;
    public bool incSpd = false;

    void Update()
    {
        if(incSpd == false)
        {
            incSpd = true;
            StartCoroutine(IncreaseSpeed());
        }
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            else if (Input.GetMouseButton(0))
            {
                if(Input.mousePosition.x < Screen.width / 2)
                {
                    if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                    }
                }
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            else if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > Screen.width / 2)
                {
                    if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                    }
                }
            }
        }
    }
    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(5.0f);
        //max speed is 35
        if (moveSpeed <= 35.0f)
        {
            moveSpeed += 1.0f;
        }
        //max speed is 20
        if (leftRightSpeed <= 25.0f)
        {
            leftRightSpeed += 0.75f;
        }
        //max speed is 0.05
        if (LevelDistance.disDelay >= 0.025f)
        {
            LevelDistance.disDelay -= 0.01f;
        }
        incSpd = false;
    }
}
