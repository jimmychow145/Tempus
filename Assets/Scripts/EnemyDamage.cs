using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float radius = 3f;               // How close do we need to be to interact?
    public Transform interactionTransform;  // The transform from where we interact in case you want to offset it
    public float distance;
    //bool isFocus = false;   // Is this interactable currently being focused?
    public Transform player;       // Reference to the player transform

    public float knockbackForce = 1;
    public float knockbackForceUp = 1;
    public float knockbackForceDistance = 1;
    public int HP = 2;
    public Item itemdrop;
    public AudioSource hitSound;

    //bool hasInteracted = false; // Have we already interacted with the object?

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        //Debug.Log("Interacting with " + transform.name);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // If we are currently being focused
        // and we haven't already interacted with the object
        // If we are close enough
        distance = Vector3.Distance(player.position, interactionTransform.position);
        if (distance <= radius && Input.GetButtonDown("Fire1"))
        {
            // Interact with the object

            Interact();
            damaged();
        }
        if (HP <= 0)
        {
            Destroy(gameObject);
            Inventory.instance.Add(itemdrop);
        }
    }

    // Called when the object starts being focused

    // Draw our radius in the editor
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    public void damaged()
    {
        hitSound.Play();
        this.GetComponent<Rigidbody>().AddExplosionForce(knockbackForce, player.position, knockbackForceDistance, knockbackForceUp, ForceMode.Impulse);
        HP--;
    }
}