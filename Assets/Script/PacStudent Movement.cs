using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector3;
using UnityEngine;
using Unity.VisualScripting;
using System.ComponentModel;

public class PacStudentMovement : MonoBehaviour
{
    public float movingSpeed = 0.2f;
    public  AudioSource movingMan;//chunjat!
    public AudioClip clip;
    public Vector2[] coordinates = 
    {
        new Vector2(-10.5f, -0.5f), new Vector2(-10.5f, 3.5f), new Vector2(-5.5f, 3.5f), new Vector2(-5.5f, -0.5f)
    };
    private Vector2 target;
    private float time = 0f;
    private int point = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(coordinates.Length > 0){
            target = coordinates[0];
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * movingSpeed / Vector2.Distance(transform.position, target);
        transform.position = Vector2.Lerp(transform.position, target, time);

        if(Vector2.Distance(transform.position, target) < 0.1f)
        {
            point++;
            if(point >= coordinates.Length)
            {
                point = 0;
            }
            target = coordinates[point];
            time = 0f;
        }

    }
}
