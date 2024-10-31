using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk : MonoBehaviour
{
    public GameObject coinObject;
    public float cooldown = 10f; // Set to 10 seconds

    void Start()
    {
        // Start repeating coin spawn every 10 seconds
        InvokeRepeating("SpawnCoin", cooldown, cooldown);
    }

    void SpawnCoin()
    {
        // Spawn coin with slight random offset from monk position
        GameObject myCoin = Instantiate(coinObject, 
            new Vector3(transform.position.x + Random.Range(-2f, 2f), 
                       transform.position.y + Random.Range(0f, .5f), 
                       0), 
            Quaternion.identity);

        // Set the drop position below the monk
        myCoin.GetComponent<Coin>().dropToYPos = transform.position.y - 1;
    }
}
