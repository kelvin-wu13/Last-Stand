using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public int damage;
    public float range;
    public LayerMask unitMask;
    public float eatCooldown;
    private bool canEat = true;
    public Unit targetUnit;

    // Reference to the Animator component
    private Animator animator;

    // Animation parameter names (set these in the Animator)
    private const string ATTACK_TRIGGER = "Attack";
    private const string DEATH_TRIGGER = "Death";
    private const string WALK_BOOL = "IsWalking";


    private void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, unitMask);

        if(hit.collider)
        {
            targetUnit = hit.collider.GetComponent<Unit>();
            Eat();
        }
    }

    void Eat()
    {
        if(!canEat || !targetUnit)
            return;

        // Stop walking when attacking
        if(animator != null)
        {
            animator.SetBool(WALK_BOOL, false);
            animator.SetTrigger(ATTACK_TRIGGER);
        }

        canEat = false;
        Invoke("ResetEatCooldown", eatCooldown);

        // Damage the target unit
        targetUnit.Hit(damage);
    }

    public void OnAttackComplete()
{
    Debug.Log("Attack animation completed");

    // Reset target if no longer in range
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, unitMask);
    
    if(hit.collider == null)
    {
        targetUnit = null;
    }

    // Set walking animation
    if(animator != null)
    {
        animator.SetBool(WALK_BOOL, true);
    }
}

    void ResetEatCooldown()
    {
        canEat = true;
    }

    private void FixedUpdate()
    {
        if(!targetUnit)
        {
            // Set walking animation
            if(animator != null)
            {
                animator.SetBool(WALK_BOOL, true);
            }
                if(!targetUnit)
            transform.position -= new Vector3(speed, 0, 0);
        }
        else
        {
            // Stop walking when target is found
            if(animator != null)
            {
                animator.SetBool(WALK_BOOL, false);
            }
        }
    }

    public void Hit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            // Trigger death animation before destroying
            if(animator != null)
            {
                animator.SetBool(WALK_BOOL, false);
                animator.SetTrigger(DEATH_TRIGGER);
                
                // Disable colliders and stop movement
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
    }
}
