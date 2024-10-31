using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float dropToYPos;
    private float speed = .1f;

    private void Start()
    {
        Destroy(gameObject, Random.Range(10f,12f));
    }

    private void Update()
    {
        if(transform.position.y > dropToYPos)
            transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }

    // Add this method to detect mouse clicks
    private void OnMouseDown()
    {
        // Add a coin to the GameManager when collected
        FindObjectOfType<GameManager>().coins += 50;
        // Destroy the coin
        Destroy(gameObject);
    }
}