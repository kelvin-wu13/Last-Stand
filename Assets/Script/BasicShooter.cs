using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootOrigin;

    public float cooldown;
    public float health;

    private bool canShoot;
    public float range;
    public LayerMask shootMask;
    private GameObject target;

    // Animator reference
    private Animator animator;

    // Animation parameter names
    private const string SHOOT_TRIGGER = "Shoot";
    private const string DEATH_TRIGGER = "Death";
    private const string IDLE_BOOL = "IsIdle";

    private void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Start with initial cooldown and idle state
        Invoke("ResetCooldown", cooldown);
        
        if(animator != null)
        {
            animator.SetBool(IDLE_BOOL, true);
        }
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);
        
        if(hit.collider)
        {
            target = hit.collider.gameObject;

            // Set idle state when not shooting
            if(animator != null)
            {
                animator.SetBool(IDLE_BOOL, false);
            }

            Shoot();
        }
        else
        {
            // Set idle state when no target
            if(animator != null)
            {
                animator.SetBool(IDLE_BOOL, true);
            }
        }
    }

    void ResetCooldown()
    {
        canShoot = true;
    }

    void Shoot()
    {
        if(!canShoot)
            return;

        canShoot = false;
        Invoke("ResetCooldown", cooldown);

        // Trigger shoot animation
        if(animator != null)
        {
            animator.SetTrigger(SHOOT_TRIGGER);
        }

        GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
    }

    // Method to be called as an animation event at the end of the shoot animation
    public void OnShootAnimationComplete()
    {
        // You can add any additional logic here after shooting
        if(animator != null)
        {
            animator.SetBool(IDLE_BOOL, true);
        }
    }

    // Method to handle taking damage
    public void Hit(int damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
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
    }

    // Optional method to be called at the end of death animation
    public void OnDeathAnimationComplete()
    {
        // Any additional cleanup or effects can be added here
        Destroy(gameObject);
    }
}