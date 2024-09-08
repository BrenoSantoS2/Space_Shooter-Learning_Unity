using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 5.0f;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-6.0f, 6.0f), 5.0f, 0);
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float spawnRange = Random.Range(-6.0f, 6.0f);

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(spawnRange, 5.0f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Lazer"))
        {
            Destroy(gameObject);
        }

        else if (other.transform.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage();
            }

            Destroy(gameObject);
        }
    }
}
