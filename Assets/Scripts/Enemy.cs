using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 5.0f;
    private Player _player;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-6.0f, 6.0f), 5.0f, 0);
        _player = GameObject.Find("Player").GetComponent<Player>();
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
        if (other.transform.CompareTag("Lazer"))
        {
            if (_player != null)
            {
                _player.AddScore(10);
            }

            Destroy(gameObject);
        }
        else if (other.transform.CompareTag("Player"))
        {
            if (_player != null)
            {
                _player.TakeDamage();
                _player.AddScore(10);
            }

            Destroy(gameObject);
        }
    }
}
