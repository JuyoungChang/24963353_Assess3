using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private Vector2 start;
    private Vector2 target;
    public float speed = 3f;
    private string lastInput;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        target = start;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement()
    {
        transform.position = Vector2.Lerp(start, target, speed * Time.deltaTime);
    }

}
