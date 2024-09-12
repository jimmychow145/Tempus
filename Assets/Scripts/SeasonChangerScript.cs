using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeasonChangerScript : MonoBehaviour
{
    public string currentSeason;
    public float radius = 3f;               // How close do we need to be to interact?
	public Transform interactionTransform;  // The transform from where we interact in case you want to offset it
	public float distance;
	//bool isFocus = false;   // Is this interactable currently being focused?
	public Transform player;       // Reference to the player transform
	public int numberOfSeasonSurvived = 0;

	//bool hasInteracted = false; // Have we already interacted with the object?

	public virtual void Interact()
	{
		// This method is meant to be overwritten
		//Debug.Log("Interacting with " + transform.name);
	}
    void Start()
    {
        interactionTransform = this.GetComponent<Transform>();
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
                changeSeason();
				numberOfSeasonSurvived++;

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

    public void changeSeason()
    {
        if(currentSeason == "Spring")
        {
            SceneManager.LoadScene("SummerWorld", LoadSceneMode.Single);
        }
        else if(currentSeason == "Summer")
        {
            SceneManager.LoadScene("AutumnWorld", LoadSceneMode.Single);
        }
        else if(currentSeason == "Autumn")
        {
            SceneManager.LoadScene("WinterWorld", LoadSceneMode.Single);
        }
        else if(currentSeason == "Winter")
        {
            SceneManager.LoadScene("SpringWorld", LoadSceneMode.Single);
        }
    }
}
