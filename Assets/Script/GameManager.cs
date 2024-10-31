using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject currentUnit;
    public Sprite currentUnitSprite;
    public Transform tiles;
    public LayerMask tileMask;
    private SpriteRenderer lastHighlightedTile;
    private Tile lastHighlightedTileComponent;
    
    [SerializeField]
    private int _coins;
    public int coins
    {
        get { return _coins; }
        set 
        { 
            _coins = value;
            if (coinText != null)
                coinText.text = _coins.ToString();
        }
    }
    
    public TextMeshProUGUI coinText;

    public void BuyUnit(GameObject unit, Sprite sprite)
    {
        Debug.Log($"BuyUnit called with: {unit.name}");
        currentUnit = unit;
        currentUnitSprite = sprite;
    }

    public void Update()
    {
        if (coinText != null)
        {
            coinText.text = coins.ToString();
        }

        if (currentUnit == null) return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        // Clear previous highlight
        if (lastHighlightedTile != null)
        {
            lastHighlightedTile.sprite = null;
        }

        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, Mathf.Infinity, tileMask);

        if (hit.collider != null)
        {
            Tile tile = hit.collider.GetComponent<Tile>();
            SpriteRenderer tileRenderer = hit.collider.GetComponent<SpriteRenderer>();
            
            if (tile != null && tileRenderer != null && !tile.hasUnit)
            {
                // Show preview
                tileRenderer.sprite = currentUnitSprite;
                lastHighlightedTile = tileRenderer;
                lastHighlightedTileComponent = tile;

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Placing unit");
                    Vector3 spawnPosition = hit.collider.transform.position;
                    GameObject spawnedUnit = Instantiate(currentUnit, spawnPosition, Quaternion.identity);
                    
                    // Set up the unit's reference to its tile
                    Unit unitComponent = spawnedUnit.GetComponent<Unit>();
                    if (unitComponent != null)
                    {
                        // Add this method to your Unit script to store the tile reference
                        unitComponent.SetTile(tile);
                    }
                    
                    tile.hasUnit = true;
                    tile.currentUnit = spawnedUnit; // Add this line to your Tile script
                    currentUnit = null;
                    currentUnitSprite = null;
                    lastHighlightedTile = null;
                    lastHighlightedTileComponent = null;
                }
            }
        }
    }
}
