using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float _speed = 3f;
    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            player?.PowerUp();

            Destroy(gameObject);
        }
    }

    void Movement()
    {
        float spawnRange = Random.Range(-6.0f, 6.0f);

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
