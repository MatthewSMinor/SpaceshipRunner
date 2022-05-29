
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int jumpSpeed = 3;
    public int playerSpeed = 5;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

    void FixedUpdate()
    {
        rb.AddForce(transform.right * playerSpeed * Time.deltaTime);

    }
}
