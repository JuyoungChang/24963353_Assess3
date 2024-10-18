using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public bool isLerping = false;
    public Vector2 lastInput = Vector2.zero;
    public Vector2 currentINput = Vector2.zero;
    private AudioSource movingSound;
    public AudioClip movingSoundClip;
    
    // Start is called before the first frame update
    void Start()
    { 
        movingSound = gameObject.AddComponent<AudioSource>();
        movingSound.clip = movingSoundClip;
    }

    // Update is called once per frame
    void Update()
    {
        InputMan();
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

}
