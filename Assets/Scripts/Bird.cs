using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    #region Global property
    public static Bird Instance { get; set; }
    public float jumpForce = 5f;
    public float minYBound = -6f;
    public float maxYBound = 6f;
    private bool isDead = false;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 temp;
    #endregion

    #region Mode Endless
    private bool isBoosted = false;
    public bool isMagnet = false;
    private Coroutine speedBoostCoroutine;
    private Coroutine magnetCoroutine;
    #endregion
    private GameManager.GameState gameState;

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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("isFlap", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            _animator.SetBool("isFlap", false);
        }
    }

    void HandleMove()
    {
        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
        {
            temp = transform.position;
            temp.x += SpeedManager.Instance.Speed * Time.deltaTime;
            transform.position = temp;
        }

        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
        {
            temp = transform.position;
            if (isBoosted)
                temp.x += SpeedManager.Instance.Speed * 3f * Time.deltaTime;
            else
                temp.x += SpeedManager.Instance.Speed * Time.deltaTime;
            transform.position = temp;
        }
    }

    public void ResetBodyType()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            if (collision.CompareTag("Obstacle"))
            {
                Die();
            }

            if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
            {
                if (collision.CompareTag("Star"))
                {
                    StarManager.Instance.IncrementStarCount();
                    Destroy(collision.gameObject);
                }
            }

            if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
            {
                if (collision.gameObject.CompareTag("Magnet"))
                {
                    isMagnet = true;
                    Destroy(collision.gameObject);
                    if (magnetCoroutine != null)
                        StopCoroutine(magnetCoroutine);
                    magnetCoroutine = StartCoroutine(MagnetCoroutine());
                }

                if (collision.gameObject.CompareTag("Coin"))
                {
                    CoinManager.Instance.CollectCoin();
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    #region Method for Endless Mode
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

    private IEnumerator MagnetCoroutine()
    {
        yield return new WaitForSeconds(5f);

        isMagnet = false;
    }
    #endregion


    private void Die()
    {
        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Normal)
        {
            NormalMode.Instance.GameOver();
        }

        if (ModeManager.Instance.CurrentMode == ModeManager.GameMode.Endless)
        {
            EndlessMode.Instance.GameOver();
        }
        isDead = true;
    }
}