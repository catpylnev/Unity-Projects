using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    int valueToSend = 9;

    // Start is called before the first frame update
    void Start()
    {
       string stringFromOutside = FindObjectOfType<Cube>().PrintingFromOutside(valueToSend);
        Debug.Log(stringFromOutside);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
