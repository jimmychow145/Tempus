using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanScript : MonoBehaviour
{
    private float lastDirectionChangeTime;
    public float DirectionChangeTime = 1f;
    public float velocity = 1f;
    private Vector3 Direction;
    private Vector3 directionPerSecond;

    public bool targeting;
    public GameObject player;
    public float targetingDistance = 15f;

    // Start is called before the first frame update
    void Start()
    {
        lastDirectionChangeTime = 0f;
        newDirection();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targeting = Vector3.Distance(transform.position, player.transform.position) < targetingDistance;

        if(targeting)
        {
            newDirection(player.transform.position);
        }
        else if(Time.time - lastDirectionChangeTime > DirectionChangeTime)
        {
            lastDirectionChangeTime = Time.time;
            newDirection();
        }

        transform.position = new Vector3(transform.position.x + (directionPerSecond.x * Time.deltaTime), transform.position.y, transform.position.z + (directionPerSecond.z * Time.deltaTime));
        transform.rotation = Quaternion.LookRotation(Direction);
    }

    public void newDirection()
    {
        Direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1,1)).normalized;
        directionPerSecond = Direction * velocity;
    }

    public void newDirection(Vector3 dir)
    {
        Direction = (new Vector3(dir.x, player.transform.position.y-1, dir.z) - transform.position).normalized;
        directionPerSecond = Direction * velocity;
    }
}
