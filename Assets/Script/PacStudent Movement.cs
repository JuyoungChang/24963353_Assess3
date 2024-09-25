using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Unity.VisualScripting;
using System.ComponentModel;

public class PacStudentMovement : MonoBehaviour
{
    public float movingSpeed = 0.2f;
    private AudioSource movingMan;//chunjat!
    public AudioClip clip;
    private Vector2[] coordinates;

    private Vector2 target;
    private float time = 0f;
    private int point = 0;

    // Start is called before the first frame update
    void Start()
    {
        movingMan = GetComponent<AudioSource>();
        coordinates = new Vector2[]
        {
             new Vector2(-10.5f, -0.5f), new Vector2(-10.5f, 3.5f), new Vector2(-5.5f, 3.5f), new Vector2(-5.5f, -0.5f)
        };

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
