using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 5f;
    public float minYBound = -6f;
    public float maxYBound = 6f;
    private Vector3 temp;
    private bool isDead = false;
    private static Bird instance;
    Rigidbody2D _rigidbody2D;
    Animator _animator;

    private GameManager.GameState gameState;
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
        if (GameManager.Instance != null)
        {
            gameState = GameManager.Instance.CurrentGameState;

            if (gameState == GameManager.GameState.InProgress)
            {
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                transform.eulerAngles = new Vector3(0, 0, _rigidbody2D.velocity.y * .2f);
                HandleFlap();

                if (temp.y > maxYBound || temp.y < minYBound)
                    Die();
            }
        }


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
        temp.x += SpeedManager.Instance.Speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            if (collision.CompareTag("Obstacle"))
            {
                Die();
            }
            if (collision.CompareTag("Item"))
            {
                StarManager.Instance.IncrementStarCount();
                Destroy(collision.gameObject);
            }
        }
    }

    private void Die()
    {
        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
        {
            NormalMode.Instance.GameOver();
        }
    }
}
