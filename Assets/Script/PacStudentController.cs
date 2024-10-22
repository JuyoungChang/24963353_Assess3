using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacStudentController : MonoBehaviour
{
    public bool isLerping = false;
    public Vector2 lastInput = Vector2.zero;
    public Vector2 currentInput;
    private AudioSource movingSound;
    public AudioClip movingSoundClip;
    private AudioSource wallCollide;
    public AudioClip wallCollideClip;
    private AudioSource eatingSound;
    public AudioClip eatingClip;
    private Animator movingAnimataor;
    private ParticleSystem particle;
    private ParticleSystem wallParticle;
    public UIManager ui;
    private Rigidbody2D rb;
    private Vector2 lastPos;
    public LayerMask wallLayerMask;
    
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();

        movingSound = gameObject.AddComponent<AudioSource>();
        movingSound.clip = movingSoundClip;

        eatingSound = gameObject.AddComponent<AudioSource>();
        eatingSound.clip = eatingClip;

        wallCollide = gameObject.AddComponent<AudioSource>();
        wallCollide.clip = wallCollideClip;

        movingAnimataor = GetComponent<Animator>();
        particle = GetComponent<ParticleSystem>();

        particle.Stop();
    }

    void Update()
    {
        InputMan();
        PacSutdentAnmimation();
        Teleport();
    }

    void InputMan()
    {
        if (Input.GetKeyDown("w") && !isLerping)
        {
            lastInput = Vector2.up;
            if (CanMove())
            {
                StartMove();
            } 
        }
        if (Input.GetKeyDown("s") && !isLerping)
        {
            lastInput = Vector2.down;
            if (CanMove()) 
            {
                StartMove();
            }
        }
        if (Input.GetKeyDown("a") && !isLerping)
        {
            lastInput = Vector2.left;
            if (CanMove()) 
            {
                StartMove();
            }
        }
        if (Input.GetKeyDown("d") && !isLerping)
        {
            lastInput = Vector2.right;
            if (CanMove()) 
            {
                StartMove();
            }
        }
    }
    private bool WallInfront(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1, wallLayerMask);
        return hit.collider != null;
    }
    private bool CanMove()
    {
        if(!WallInfront(lastInput))
        {
            return true;
        }else{
            wallCollide.Play();
            return false;
        }
    }
    private void StartMove()
    {
        lastPos = transform.position;
        Vector2 targetPosition = (Vector2)transform.position + lastInput;   
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            
            wallCollide.Play();
            transform.position = lastPos; 
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
