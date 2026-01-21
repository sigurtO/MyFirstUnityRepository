using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float jumpForce;
    [SerializeField]
    public SpriteRenderer sprite;

    [SerializeField] 
    public int FallDeathNum = -4;

    [SerializeField]
    public TextMeshProUGUI scoreText;

    private bool isGrounded;

    public int score;

    private void FixedUpdate() //physcis
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocityY);
        if (rb.linearVelocity.x > 0)
        {
            sprite.flipX = true;
        }
        else if (rb.linearVelocity.x < 0)
        {
            sprite.flipX = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (transform.position.y < FallDeathNum)
        {
            GameOver();
        }   

    }
    //Collision stay checks if the player is grounded everyframe
    private void OnCollisionStay2D(Collision2D collision) // current bug that allows double jumping due to "sticky feet" fix by adding a slight cooldown after jumping so cannot instant change to true like .3 sec should do it
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.8f)
            {
                isGrounded = true;
                return;
            }
        }

    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
