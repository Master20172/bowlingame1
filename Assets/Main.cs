using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [HideInInspector]
        public string displaynewtext;

    public Transform testCube;

    public float rotateSpeed;

    [SerializeField]
    string displaytext = "Game Started!";
    // Start is called before the first frame update -> comment
    void Start()
    {
        Debug.Log(displaytext);
    }

    // Update is called once per frame -> comment
    void Update()
    {
        //Transform.Translate(Vector3.up);
        
        //testCube.Rotate(new Vector3(0, 1, 0) * rotatespeed *Time.deltaTime);
        testCube.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
