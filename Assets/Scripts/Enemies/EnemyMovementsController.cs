using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementsController : MonoBehaviour
{
    [SerializeField] private Vector2[] _targetPositions;
    [SerializeField] private float _speed;
    private int _index;
    private AnimationsController _animationsController;

    void Start()
    {
        _animationsController = GetComponent<AnimationsController>();
    }

    void Update()
    {
        MoveToTargetPositions();
    }

    private void MoveToTargetPositions()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPositions[_index], _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _targetPositions[_index]) <= 0.1f)
        {
            _index++;
            _index %= _targetPositions.Length;
            _animationsController.SetSpriteFlip(!_animationsController.SpriteIsFlipped);
        }
    }
}
