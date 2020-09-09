using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private bool jump;
    private bool isGrounded;
    private Vector3 moveDirection;

    public float jumpPower = 1f;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        jump = Input.GetButton("Jump");

        moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);


    }

    void FixedUpdate()
    {
        Jump();
        Move();
    }

    void Move()
    {
        rb.AddForce(moveDirection * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            if (count >= 20)
                winText.text = "You win!";
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
    void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1);
        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

}