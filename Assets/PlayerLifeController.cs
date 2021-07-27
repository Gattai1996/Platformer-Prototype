using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeController : MonoBehaviour
{
    private int _hitPoints = 4;
    private Collider2D _collider2D;
    private PlayerMovementsController _playerMovementsController;
    [SerializeField] private LayerMask _layerMask;
    private bool _delayDamage;

    private void Start()
    {
        _collider2D = GetComponent<CapsuleCollider2D>();
        _playerMovementsController = GetComponent<PlayerMovementsController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_delayDamage && _collider2D.IsTouchingLayers(_layerMask))
        {
            _hitPoints--;
            StartCoroutine(DelayDamage());
            UserInterfaceManager.Singleton.SetPlayerLife(_hitPoints);
            _playerMovementsController.ApllyForce(3);

            if (_hitPoints <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private IEnumerator DelayDamage()
    {
        _delayDamage = true;
        yield return new WaitForSeconds(0.5f);
        _delayDamage = false;
    }
}
