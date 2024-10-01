using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float _speed = 3f;

    [SerializeField]
    private int _powerUpID;

    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                switch (_powerUpID)
                {
                    case 0:
                        player.TripleShot();
                        break;
                    case 1:
                        player.SpeedBoost();
                        break;
                    case 2:
                        player.Shield();
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
            }
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
