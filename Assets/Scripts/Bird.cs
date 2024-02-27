using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 5f;
    public float minYBound = -5f;
    public float maxYBound = 5f;
    private Vector3 temp;
    private bool isDead = false;
    private static Bird instance;
    Rigidbody2D _rigidbody2D;
    Animator _animator;
    public static Bird GetInstance() => instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    private void Update()
    {
        if (GameManager.GetInstance().isGameStart)
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            HandleFlap();
        }

        if (temp.y > maxYBound || temp.y < minYBound)
            Debug.Log("BIRD DEATH");

        if (isDead)
            return;

        HandleMove();
    }

    void HandleFlap()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("isFlap", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("isFlap", false);
        }
    }

    void HandleMove()
    {
        temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Death");
            // Add Bird Die()
        }
        if (collision.CompareTag("Item"))
        {
            StarManager.GetInstance().CollectStar();
            Destroy(collision.gameObject);
        }
    }
}
