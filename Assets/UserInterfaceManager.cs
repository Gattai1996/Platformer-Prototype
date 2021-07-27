using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterfaceManager : MonoBehaviour
{
    public static UserInterfaceManager Singleton { get; private set; }
    [SerializeField] private Image _playerLifeIndicator;
    [SerializeField] private TextMeshProUGUI _playerCoinsIndicator;

    void Start()
    {
        Singleton = this;
    }

    public void SetPlayerLife(int playerCurrentLife)
    {
        _playerLifeIndicator.fillAmount = (float)playerCurrentLife * 100 / 4 / 100;
    }

    public void SetPlayerCoins(int playerCurrentCoins)
    {
        _playerCoinsIndicator.text = playerCurrentCoins.ToString();
    }
}
