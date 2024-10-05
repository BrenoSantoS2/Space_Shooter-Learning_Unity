using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject _player;

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

        transform.Translate(_speed * Time.deltaTime * Vector3.down);

        if(transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(spawnRange, 5.0f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = _player.transform.GetComponent<Player>();

        if (other.transform.CompareTag("Lazer"))
        {
            if (player != null)
            {
                player.AddScore(10);
            }

            Destroy(gameObject);
        }
        else if (other.transform.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage();
                player.AddScore(10);
            }

            Destroy(gameObject);
        }
    }
}
