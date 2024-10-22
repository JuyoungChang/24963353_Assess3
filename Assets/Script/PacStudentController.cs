using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using TMPro;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PacStudentController : MonoBehaviour
{
    public bool isLerping = false;
    public Vector2 lastInput = Vector2.zero;
    public Vector2 currentInput;
    private AudioSource movingSound;
    public AudioClip movingSoundClip;
    private AudioSource eatingSound;
    public AudioClip eatingClip;
    private Animator movingAnimataor;
    private ParticleSystem particle;
    private UIManager ui;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    { 
        ui = gameObject.GetComponent<UIManager>();
        rb = GetComponent<Rigidbody2D>();

        movingSound = gameObject.AddComponent<AudioSource>();
        movingSound.clip = movingSoundClip;

        eatingSound = gameObject.AddComponent<AudioSource>();
        eatingSound.clip = eatingClip;

        movingAnimataor = GetComponent<Animator>();
        particle = GetComponent<ParticleSystem>();

        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        InputMan();
        PacSutdentAnmimation();
        Teleport();
    }

    void InputMan()
    {
        if(Input.GetKeyDown("w") && !isLerping)
        {
            lastInput = Vector2.up;
            StartMove();
        }
        if(Input.GetKeyDown("s") && !isLerping)
        {
           lastInput = Vector2.down;
           StartMove();
        }
        if(Input.GetKeyDown("a") && !isLerping)
        {
           lastInput = Vector2.left;
           StartMove();
        }
        if(Input.GetKeyDown("d") && !isLerping)
        {
           lastInput = Vector2.right;
           StartMove();
        }
    }

    private void StartMove()
    {
        Vector2 position = transform.position;
        Vector2 targetPosition = position + lastInput;
        StartCoroutine(Movement(targetPosition));
    }
    private IEnumerator Movement(Vector2 target)
    {
        movingSound.Play();
        particle.Play();
        isLerping = true;
        Vector2 start = transform.position;
        float elapsed = 0;
        while(elapsed < 1f )
        {
            transform.position = Vector2.Lerp(start, target, elapsed);
            elapsed += Time.deltaTime * 5f;
            yield return null;  
        }
        transform.position = target;
        isLerping =false;
        particle.Stop();
    }

    public void PacSutdentAnmimation()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movingAnimataor.SetFloat("Horizontal", horizontal);
        movingAnimataor.SetFloat("Vertical", vertical);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
            isLerping = false;
        }
    }

    private void Teleport()
    {
        Vector2 currentPos = gameObject.transform.position;
        if(currentPos.y == -9.5f && currentPos.x < -11.5f)
        {
            gameObject.transform.position = new Vector2(15.5f, -9.5f);
        }
        else if(currentPos.y == -10.5f && currentPos.x < -11.5f)
        {
            gameObject.transform.position = new Vector2(15.5f, -10.5f);
        }
        else if(currentPos.y == -9.5f && currentPos.x > 15.5f)
        {
            gameObject.transform.position = new Vector2(-11.5f, -9.5f);
        }
        else if(currentPos.y == -10.5f && currentPos.x > 15.5f)
        {
            gameObject.transform.position = new Vector2(-11.5f, -10.5f);
        }
    }
}
