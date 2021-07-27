using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform _camera;
    private Vector3 _lastCameraPosition;
    private float relativePosition = 0.2f;
    private Texture2D _texture2D;
    private SpriteRenderer _spriteRenderer;
    private float _pixelsPerUnitX;

    void Start()
    {
        _camera = Camera.main.transform;
        _lastCameraPosition = _camera.position;
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _texture2D = _spriteRenderer.sprite.texture;
        _pixelsPerUnitX = _texture2D.width / _spriteRenderer.sprite.pixelsPerUnit;
    }

    void Update()
    {
        Vector2 movement = _camera.transform.position - _lastCameraPosition;
        transform.position += new Vector3(movement.x * relativePosition, movement.y * relativePosition, 0f);
        _lastCameraPosition = _camera.transform.position;

        float differenteX = _camera.position.x - transform.position.x;

        if (Mathf.Abs(differenteX) >= _pixelsPerUnitX)
        {
            float fixedX = differenteX % _pixelsPerUnitX;
            transform.position = new Vector2(_camera.position.x + fixedX, transform.position.y);
        }
    }
}
