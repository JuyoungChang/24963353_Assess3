using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector3;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public float movingSpeed = 0.2f;
    public  AudioSource movingMan;//chunjat!
    public Vector2[] coordinates = {
        new Vector2(-10.5f, -0.5f), new Vector2(-10.5f, 3.5f), new Vector2(-5.5f, 3.5f), new Vector2(-5.5f, -0.5f)
    };
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
       
    }
}
