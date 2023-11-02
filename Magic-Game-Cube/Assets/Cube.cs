using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;

    int numberOfTimes = 5;
    string nameOfTheKey = "ENTER";
    float speedOfBreaking = 6.94f;
    // Start is called before the first frame update
    void Start()
    {
       // PrintingToOurConsole();
    }

    // Update is called once per frame
    void Update()
    {
        MovingOurCube();
        OutOfBounds();

    }

    public string PrintingFromOutside(int value)
    {
       string printingSomething = "The value we were sent is " + value + ".";
        return printingSomething;
    }

    private void OutOfBounds()
    {
        if (transform.position.x > 9.7f)
        {
            Debug.LogWarning("Our cube is out of bounds to the right side!!");
        }

        else if (transform.position.x < -9.7f)
        {
            Debug.LogWarning("Our cube is out of bounds to the left side!!");
        }

        else if (transform.position.y > 5.7f)
        {
            Debug.LogWarning("Our cube is out of bounds to the top side!!");
        }
    }

    private void MovingOurCube()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidBody2D.velocity = new Vector2(0f, 10f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidBody2D.velocity = new Vector2(10f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidBody2D.velocity = new Vector2(0f, -10f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidBody2D.velocity = new Vector2(-10f, 0f);
        }
    }

    private void PrintingToOurConsole()
    {
        Debug.Log("If you press the up arrow you'll jump.");
        Debug.Log("If you press the right arrow " + numberOfTimes + "times, you'll move.");

        Debug.LogWarning("If you press the " + nameOfTheKey + " key, nothing happens.");
        Debug.LogError("Do not smash the keyboard at a speed of " + speedOfBreaking + ".");
    }
}
