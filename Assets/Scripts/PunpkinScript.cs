using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunpkinScript : MonoBehaviour
{
    private Rigidbody rb;
    private float lastJumpTime;
    public float jumpInterval = 3f;
    public float jumpHeight = 30f;
    public float jumpDistance = 10f;

    public bool targeting;
    public GameObject player;
    public float targetingDistance = 15f;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        lastJumpTime = 0f;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targeting = Vector3.Distance(transform.position, player.transform.position) < targetingDistance;
        dir = player.transform.position;

        if(targeting && Time.time - lastJumpTime > jumpInterval)
        {
            lastJumpTime = Time.time;
            rb.AddForce(new Vector3((dir.x - transform.position.x)/2, jumpHeight, (dir.z - transform.position.z)/2), ForceMode.Impulse);
        }
        else if(Time.time - lastJumpTime > jumpInterval)
        {
            lastJumpTime = Time.time;
            rb.AddForce(new Vector3(Random.Range(-jumpDistance, jumpDistance)*3 , Random.Range(1, jumpHeight) + 5, Random.Range(-jumpDistance, jumpDistance)*3), ForceMode.Impulse);
        }
    }
}
