using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TriggerAnimation(string animationParameter)
    {
        _animator.SetTrigger(animationParameter);
    }

    public void TriggerAnimation(string animationParameter, bool boolean)
    {
        _animator.SetBool(animationParameter, boolean);
    }

    public void SetSpriteFlip(bool isFlipped)
    {
        _spriteRenderer.flipX = isFlipped;
    }
}
