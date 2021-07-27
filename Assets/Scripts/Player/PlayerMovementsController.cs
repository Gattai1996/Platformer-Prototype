using UnityEngine;

public class PlayerMovementsController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpSpeed;
    private bool _isOnGround;
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimationsController _playerAnimationsController;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimationsController = GetComponent<PlayerAnimationsController>();
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
}
