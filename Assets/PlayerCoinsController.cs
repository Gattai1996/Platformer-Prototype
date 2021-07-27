using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinsController : MonoBehaviour
{
    private int _coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            _coins++;
            UserInterfaceManager.Singleton.SetPlayerCoins(_coins);
            Destroy(collision.gameObject);
        }
    }
}
