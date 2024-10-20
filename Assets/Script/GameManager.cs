using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject currentUnit;
    public Sprite currentUnitSprite;

    public Transform tiles;

    public LayerMask tileMask;

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        foreach(Transform tile in tiles)
            tile.GetComponent<SpriteRenderer>().enabled = false;

        if(hit.Collider && currentUnit)
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentUnitSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
