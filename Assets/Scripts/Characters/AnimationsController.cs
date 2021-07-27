using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public bool SpriteIsFlipped { get; private set; }   

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteIsFlipped = _spriteRenderer.flipX;
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
        SpriteIsFlipped = isFlipped;
    }
}
