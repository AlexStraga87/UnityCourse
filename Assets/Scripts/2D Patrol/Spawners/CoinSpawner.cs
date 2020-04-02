using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private int _maxCoins;
    private int _coinCount;

    private void Start()
    {
        for (int i = 0; i < _maxCoins; i++)
        {
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        _coinCount++;
        Vector2 coinPosition = new Vector2();
        coinPosition.x = Random.Range(-6, 28);
        coinPosition.y = 5.5f - Random.Range(0, 4) * 2;
        var newCoin = Instantiate(_template, coinPosition, Quaternion.identity, transform);
        newCoin.Init(this);
    }

    public void OnCoinTaked()
    {
        _coinCount--;
        StartCoroutine(CreateCoinDelay());
    }

    private IEnumerator CreateCoinDelay()
    {
        yield return new WaitForSeconds(2);
        SpawnCoin();
    }

}
