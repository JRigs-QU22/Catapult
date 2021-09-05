using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catapult : MonoBehaviour
{
    public float RotateTime;
    public int force;
    public Text CurrentForce;
    bool RotateStart;

    // Start is called before the first frame update
    void Start()
    {
        force = 70;
        RotateTime = 0.3f;
        RotateStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) //pressing right arrow key builds force
        {
            force = force + 35;
            CurrentForce.text = "Current Force is: " + force;
        }
        if (Input.GetKeyDown(KeyCode.Space)) //Pressing space sets bool to allow rotation
        {
            RotateStart = true;
        }
        if (RotateStart == true)
        {
            if (RotateTime > 0.1)
            {
                if (Input.GetKeyDown(KeyCode.Space)) //Clicking Spacebar will lauch object
                {
                    RotateStart = true;
                    GetComponent<Rigidbody2D>().angularVelocity = -force; 
                }
                RotateTime -= Time.deltaTime; //subtracts time to stop rotation
            }
            else
            {
                GetComponent<Rigidbody2D>().angularVelocity = 0; //stops rotation after time
            }
        }
    }
}
