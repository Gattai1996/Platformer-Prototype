using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform _camera;
    private float relativePosition = 0.2f;

    void Start()
    {
        _camera = Camera.main.transform;
    }

    void Update()
    {
        transform.position = new Vector2(_camera.position.x * relativePosition, _camera.position.y * relativePosition);
    }
}
