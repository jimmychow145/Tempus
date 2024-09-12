using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStat : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public float hunger = 100;
    public float hydration = 100;
    public float decRate = 1f;

    public HealthBar healthBar;
    public HungerBar hungerBar;
    public HydrationBar hydrationBar;

    public Stat damage;
    public Stat armor;
    public Stat speed;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name != "IntroScene");
        if (SceneManager.GetActiveScene().name != "IntroScene")
        {
            if(SceneManager.GetActiveScene().name != "DirectionScene")
            {
                if (hunger >= 0)
                {
                    hunger -= decRate * Time.deltaTime;
                    Debug.Log("hp down");
                }
                if (hydration >= 0)
                {
                    hydration -= decRate * Time.deltaTime;
                }
            }
            
        }

        healthBar.SetHealth(currentHealth);
        hungerBar.SetHunger(hunger);
        hydrationBar.SetHydration(hydration);
        if (hunger <= 0 && currentHealth >= 0)
        {
            currentHealth -= decRate * Time.deltaTime;
        }
        if (hydration <= 0 && currentHealth >= 0)
        {
            currentHealth -= decRate * Time.deltaTime;
        }
        if (currentHealth <= 0)
        {
            if (SceneManager.GetActiveScene().name != "DeathScene")
            {
                SceneManager.LoadScene("DeathScene");
            }
        }
    }

    public void Reset()
    {
        maxHealth = 100;
        currentHealth = 100;
        hunger = 100;
        hydration = 100;
        healthBar.SetHealth(currentHealth);
        hungerBar.SetHunger(hunger);
        hydrationBar.SetHydration(hydration);
        damage.Reset(1);
        armor.Reset(0);
        speed.Reset(1000);
        gameObject.transform.position = new Vector3(438.1f, 20.27f, 319.4f);
    }

    public void AddHunger(float hunger1)
    {
        hunger += hunger1;
        Debug.Log("added hunger");
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes " + damage + "damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way
        //Overwrite
        Debug.Log(transform.name + "died.");
    }
}