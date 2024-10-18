using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    { 
        movingSound = gameObject.AddComponent<AudioSource>();
        movingSound.clip = movingSoundClip;

        eatingSound = gameObject.AddComponent<AudioSource>();
        eatingSound.clip = eatingClip;

        movingAnimataor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMan();
        PacSutdentAnmimation();
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
    }

    public void PacSutdentAnmimation()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        /*
        if(Input.GetKey("w") && !isLerping)
        {
            lastInput = Vector2.up;
            vertical = 1f;
        }
        else if(Input.GetKey("s") && !isLerping)
        {
           lastInput = Vector2.down;
           vertical = -1f;
        }
        if(Input.GetKey("a") && !isLerping)
        {
           lastInput = Vector2.left;
           horizontal = -1f;
        }
        else if(Input.GetKey("d") && !isLerping)
        {
           lastInput = Vector2.right;
           horizontal = 1f;
        }
        Debug.Log("x" + horizontal + vertical);
        */
        movingAnimataor.SetFloat("Horizontal", horizontal);
        movingAnimataor.SetFloat("Vertical", vertical);
    }


}
