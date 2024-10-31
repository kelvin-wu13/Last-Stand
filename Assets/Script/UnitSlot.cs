using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitSlot : MonoBehaviour
{
    public Sprite unitSprite;
    public GameObject unitObject;
    public int price;
    
    public Image icon;
    public TextMeshProUGUI priceText;
    public GameManager gms;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("No Button component found on UnitSlot!");
            return;
        }

        if (gms == null)
        {
            gms = GameObject.FindObjectOfType<GameManager>();
        }

        button.onClick.AddListener(BuyUnit);
        Debug.Log("Button listener added");
    }

    private void BuyUnit()
    {
        // Check if we have enough coins AND there isn't currently a unit selected
        if(gms.coins >= price && gms.currentUnit == null)
        {
            if (gms == null)
            {
                Debug.LogError("GameManager reference is missing!");
                return;
            }

            if (unitObject == null)
            {
                Debug.LogError("Unit prefab is missing!");
                return;
            }

            Debug.Log($"Buying unit: {unitObject.name}");
            gms.coins -= price;  // Subtract coins after confirming we can buy
            gms.BuyUnit(unitObject, unitSprite);
        }
        else
        {
            Debug.Log("Cannot buy unit: " + (gms.coins < price ? "Not enough coins" : "Unit already selected"));
        }
    }

    private void OnValidate()
    {
        if(unitSprite)
        {
            icon.enabled = true;
            icon.sprite = unitSprite;
            priceText.text = price.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }

    private void Reset()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            button = gameObject.AddComponent<Button>();
        }
    }
}