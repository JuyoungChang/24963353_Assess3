using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Unity.VisualScripting;
using System.ComponentModel;

public class PacStudentMovement : MonoBehaviour
{
    public float movingSpeed = 0.05f;
    private AudioSource movingSource;
    public AudioClip movingClip;
    private Vector2[] coordinates;
    private Vector2 target;
    private Vector2 direction;
    private float time = 0f;
    private int point = 0;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        movingSource = gameObject.AddComponent<AudioSource>();
        movingSource.clip = movingClip;
        movingSource.loop = true;
        movingSource.pitch= 1.5f;
        movingSource.Play();
       
       animator = GetComponent<Animator>();

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
        direction = target -(Vector2)transform.position;
        AnimationByDirection();

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

    private void AnimationByDirection(){
        if (direction.y > 0 && direction.y >= direction.x && direction.y >= -direction.x)
        {
            animator.SetInteger("Direction", 1);  
        }
        else if (direction.y < 0 && direction.y <= direction.x && direction.y <= -direction.x)
        {
            animator.SetInteger("Direction", 2);  
        }
        else if (direction.x > 0)
        {
            animator.SetInteger("Direction", 4);  
        }
        else if (direction.x < 0)
        {
            animator.SetInteger("Direction", 3);  
        }
    }

}
