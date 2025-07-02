using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private float _jumpPower = 5f;

    private bool _onGround;
    private bool _isSliding;

    private float _slideTimer;

    private void Start()
    {
        _onGround = true;
    }

    public void Update()
    {
        if (_isSliding)
        {
            _slideTimer += Time.deltaTime;
            if (_slideTimer >= 5f)
            {
                _isSliding = false;
                _animator.SetTrigger("Cancel");
                _slideTimer = 0f;
            }
        }
    }

    public void Jump()
    {
        if (_onGround)
        {
            _onGround = false;
            _animator.SetTrigger("Jump");
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    public void Sliding()
    {
        _slideTimer = 0f;
        _isSliding = true;
        _animator.SetTrigger("Sliding");

    }

    public void SlidingCancel()
    {
        if (!_isSliding) return;

        _isSliding = false;
        _animator.SetTrigger("Cancel");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("SlopeDown") ||
            collision.gameObject.CompareTag("SlopeUp"))
        {
            if (!_onGround)
            {
                _animator.SetTrigger("Cancel");
                _onGround = true;
            }
        }
    }
}

