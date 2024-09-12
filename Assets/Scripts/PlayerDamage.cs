using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public float knockbackForce = 1;
    public float knockbackForceUp = 1;
    public float knockbackForceDistance = 1;
    public float beeDanamge;
    public float mosquitoDanamge;
    public float pumpkinDanamge;
    public float snowmanDanamge;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bee")
        {
            takeDamage(beeDanamge);
            this.GetComponent<Rigidbody>().AddExplosionForce(knockbackForce, col.contacts[0].point + new Vector3(0, 1, 0), knockbackForceDistance, knockbackForceUp, ForceMode.Impulse);
        }
        if(col.gameObject.tag == "Mosquito")
        {
            takeDamage(mosquitoDanamge);
        }
        if(col.gameObject.tag == "Pumpkin")
        {
            takeDamage(pumpkinDanamge);
        }
        if(col.gameObject.tag == "Snowman")
        {
            takeDamage(snowmanDanamge);
        }
    }

    public void takeDamage(float dam)
    {
        slider.value -= dam;
    }
    public void addhealth(float health)
    {
        slider.value += health;
    }
}
