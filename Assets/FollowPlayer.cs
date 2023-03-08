using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;
    public float attackDistance = 5f;
    public float minimumDistance = 2f;
    public Animation attackAnimation;

    void Start()
    {
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance > minimumDistance)
        {
            direction = direction.normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            if (distance <= attackDistance)
            {
                if (!attackAnimation.isPlaying)
                {
                    attackAnimation.Play();
                }
            }
        }

        // Make the monster face the player
        transform.LookAt(player.transform);
    }
}
