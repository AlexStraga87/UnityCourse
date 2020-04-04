using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private int _maxCoins;
    private List<Coin> _coinPool;

    private void Start()
    {
        InitilizePool();
        for (int i = 0; i < _maxCoins; i++)
        {
            SpawnCoin();
        }
    }

    private void InitilizePool()
    {
        _coinPool = new List<Coin>();
        for (int i = 0; i < _maxCoins; i++)
        {
            var newCoin = Instantiate(_template, Vector3.zero, Quaternion.identity, transform);
            newCoin.OnTaken += OnCoinTaked;
            _coinPool.Add(newCoin);
            newCoin.gameObject.SetActive(false);
        }
    }

    private void SpawnCoin()
    {
        var coin = _coinPool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        if (coin != null)
        {
            Vector2 coinPosition = new Vector2();
            coinPosition.x = Random.Range(-6, 28);
            coinPosition.y = 5.5f - Random.Range(0, 4) * 2;
            coin.transform.position = coinPosition;
            coin.gameObject.SetActive(true);
        }
    }

    public void OnCoinTaked()
    {
        StartCoroutine(CreateCoinDelay());
    }

    private IEnumerator CreateCoinDelay()
    {
        yield return new WaitForSeconds(2);
        SpawnCoin();
    }
    
    private void OnDestroy()
    {
        foreach (var coin in _coinPool)
        {
            coin.OnTaken -= OnCoinTaked;
        }
    }
}
