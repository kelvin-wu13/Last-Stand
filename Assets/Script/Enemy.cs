using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float health;

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }
}
