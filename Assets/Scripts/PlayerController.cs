using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Public variables
    public float speed;
    public float jump;
    public float detectionRadius;
    public float jumpTime;
    public float multiplier;
    public float milestone;
    public bool isGrounded;
    public LayerMask ground;
    public Transform groundDetection;
    public Animator animator;
    public GameObject deathMenu;
    public ParticleSystem deathParticle;
    public AudioSource jumpAudio;
    public AudioSource pickup;
    public AudioSource powerup;


    //Private variables
    private Rigidbody2D rb;
    private float counter;
    private float milestoneLimit;
    private bool isFalling;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        counter = jumpTime;
        milestoneLimit = milestone;
    }

    void Update()
    {
        deathParticle.transform.position = transform.position;

        isGrounded = Physics2D.OverlapCircle(groundDetection.position, detectionRadius, ground);

        if (transform.position.x > milestoneLimit)
        {
            milestoneLimit += milestone;

            milestone = milestone * multiplier;

            speed = speed * multiplier;
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded )
            {
                jumpAudio.Play();
                rb.velocity = new Vector2(rb.velocity.x, jump);
                animator.SetBool("isJumping", true);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (counter > 0 && !isFalling)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                counter -= Time.deltaTime;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            counter = 0;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (isGrounded)
            {
                jumpAudio.Play();
                rb.velocity = new Vector2(rb.velocity.x, jump);
                animator.SetBool("isJumping", true);
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                if (counter > 0 && !isFalling)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jump);
                    counter -= Time.deltaTime;
                }
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                counter = 0;
            }
        }

        if (isGrounded)
        {
            counter = jumpTime;
            isFalling = false;
        }

        if (rb.velocity.y < 0)
        {
            isFalling = true;
        }

        animator.SetBool("isJumping", !isGrounded);

        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            gameObject.SetActive(false);
            ScoreManager.isIncreasing = false;
            speed = 0;
            deathMenu.SetActive(true);
            deathParticle.Play();
            
        }
        if (col.gameObject.tag == "Pickup")
        {
            pickup.Play();
        
        }
        if (col.gameObject.tag == "Powerup")
        {
            powerup.Play();

        }
    }

    /*public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public IEnumerator RestartLevel()
    {
        speed = 0;
        yield return new WaitForSeconds(1);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    */
}
