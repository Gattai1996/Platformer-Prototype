using UnityEngine;

public class PlayerMovementsController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpSpeed;
    private bool _isOnGround;
    private Rigidbody2D _rigidbody2D;
    private AnimationsController _playerAnimationsController;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimationsController = GetComponent<AnimationsController>();
    }

    private void Update()
    {
        MovePlayerWithInputs();
    }

    private void MovePlayerWithInputs()
    {
        float xVelocity = Input.GetAxis("Horizontal") * _movementSpeed;
        float yVelocity = _rigidbody2D.velocity.y;
        _isOnGround = yVelocity == 0f;

        if (_isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity = _rigidbody2D.velocity.y + _jumpSpeed;
            _playerAnimationsController.TriggerAnimation("Jump");
        }

        Vector2 velocity = new Vector2(xVelocity, yVelocity);
        _rigidbody2D.velocity = velocity;

        _playerAnimationsController.TriggerAnimation("Running", xVelocity != 0f);
        _playerAnimationsController.TriggerAnimation("OnGround", _isOnGround);

        if (xVelocity < -0.1f)
        {
            _playerAnimationsController.SetSpriteFlip(true);
        }

        if (xVelocity > 0.1f)
        {
            _playerAnimationsController.SetSpriteFlip(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 10)
        {
            Destroy(collision.collider.transform.parent.gameObject);
            ApllyForce(5, false);
        }
    }

    public void ApllyForce(int multiplier, bool backForce)
    {
        _rigidbody2D.AddForce(Vector2.up * multiplier, ForceMode2D.Impulse);

        if (backForce)
        {
            _rigidbody2D.AddForce(transform.forward * -1 * multiplier, ForceMode2D.Impulse);
        }
    }
}
