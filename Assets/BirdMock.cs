using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMock : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float minYBound = -6f;
    public float maxYBound = 6f;
    private Vector3 temp;
    private bool isDead = false;
    private bool isBoosted = false;
    public bool isMagnet = false;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Coroutine speedBoostCoroutine;
    private Coroutine magnetCoroutine;
    public static BirdMock Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
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
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        transform.eulerAngles = new Vector3(0, 0, _rigidbody2D.velocity.y * .2f);
        HandleFlap();

        if (temp.y > maxYBound || temp.y < minYBound)
            Debug.Log("DEATH");

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
        if (isBoosted)
            temp.x += speed * 3f * Time.deltaTime;
        else
            temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    public void ActivateSpeedBoost()
    {
        if (speedBoostCoroutine != null)
            StopCoroutine(speedBoostCoroutine);

        speedBoostCoroutine = StartCoroutine(SpeedBoostCoroutine());
    }

    IEnumerator SpeedBoostCoroutine()
    {
        isBoosted = true;

        yield return new WaitForSeconds(5f);

        isBoosted = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Magnet"))
        {
            isMagnet = true;
            Destroy(other.gameObject);
            if (magnetCoroutine != null)
                StopCoroutine(magnetCoroutine);
            magnetCoroutine = StartCoroutine(MagnetCoroutine());
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator MagnetCoroutine()
    {
        yield return new WaitForSeconds(5f);

        isMagnet = false; 
    }
}
