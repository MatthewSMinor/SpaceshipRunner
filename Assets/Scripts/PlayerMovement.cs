using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text scoreText;
    public int jumpSpeed = 3;
    public int playerSpeed = 5;
    private Rigidbody2D rb;

    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(PlayerScoreCalculator());
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(jumpSpeed/2, jumpSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Astroid")
        {
            Application.LoadLevel("TitleScreen");
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * playerSpeed * Time.deltaTime);

    }

    public IEnumerator PlayerScoreCalculator()
    {
        while(true)
        {
            playerScore += 5;
            scoreText.GetComponent<UnityEngine.UI.Text>().text = $"Distance: {playerScore}";

            yield return new WaitForSeconds(5);   
        }
    }
}
