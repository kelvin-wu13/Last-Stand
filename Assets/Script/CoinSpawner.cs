using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinObject;

    private void Start()
    {
        SpawnCoin();
    }

    void SpawnCoin()
    {
        GameObject myCoin = Instantiate(coinObject, new Vector3(Random.Range(-9.74f, 6.61f), 6, 0), Quaternion.identity );
        myCoin.GetComponent<Coin>().dropToYPos = Random.Range(2.19f, -2.87f);
        Invoke("SpawnCoin", Random.Range(6f, 10f));
    }
}
