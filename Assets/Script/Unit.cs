using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;
    private Tile currentTile;

    // Animator reference
    private Animator animator;

    // Animation parameter names
    private const string DEATH_TRIGGER = "Death";

    private void Start()
    {
        // Set layer to unit layer
        gameObject.layer = 9;

        // Get Animator component
        animator = GetComponent<Animator>();
    }

    public void SetTile(Tile tile)
    {
        currentTile = tile;
    }

    public void Hit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            // Trigger death sequence
            Die();
        }
    }

    private void Die()
    {
        // Clear tile references
        if(currentTile != null)
        {
            currentTile.hasUnit = false;
            SpriteRenderer tileRenderer = currentTile.GetComponent<SpriteRenderer>();
            if(tileRenderer != null)
            {
                tileRenderer.sprite = null;
            }
        }

        // Trigger death animation
        if(animator != null)
        {
            animator.SetTrigger(DEATH_TRIGGER);
            
            // Disable colliders
            Collider2D[] colliders = GetComponents<Collider2D>();
            foreach(var collider in colliders)
            {
                collider.enabled = false;
            }

            // Destroy the game object after animation completes
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
        else
        {
            // Fallback if no animator is present
            Destroy(gameObject);
        }
    }

    // Optional method to be called at the end of death animation
    public void OnDeathAnimationComplete()
    {
        // Any additional cleanup or effects can be added here
        Destroy(gameObject);
    }
}