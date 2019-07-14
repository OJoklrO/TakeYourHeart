using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find : MonoBehaviour
{
    string str = "";
    GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Gurad");
    }

    // Update is called once per frame
    void Update()
    {
        str = "";
        foreach (var x in gameObjects)
        {
            str = str + x.name + x.transform.position.ToString();
        }
        //Debug.Log(str);
    }
}
