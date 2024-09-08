using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _lazerPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _nextTime = 0f;
    [SerializeField]
    private int _lives = 3;

    private SpawnerManager _spawnerManager;

    void Start()
    {
        _spawnerManager = GameObject.Find("Spawner_Manager").GetComponent<SpawnerManager>();
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame 
    void Update()
    {
        Move();
        InvisibleWall();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextTime)
        {
            ShootLazer();
        }
    }

    void Move()
    {
        float speed = 5.0f;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new(horizontalInput, verticalInput, 0);

        transform.Translate(speed * Time.deltaTime * direction);
    }

    void InvisibleWall()
    {
        float playerY = transform.position.y;
        float playerX = transform.position.x;
        float verticalLimit = 4.5f;
        float horizontalLimit = 8.4f;

        transform.position = new Vector3(Mathf.Clamp(playerX, -horizontalLimit, horizontalLimit), Mathf.Clamp(playerY, -verticalLimit, verticalLimit), 0);
    }

    void ShootLazer()
    {
        Vector3 lazerOffSet = new(transform.position.x, transform.position.y + 0.8f, 0);

        _nextTime = Time.time + _fireRate;
        Instantiate(_lazerPrefab, lazerOffSet, Quaternion.identity);

    }

    public void TakeDamage()
    {
        _lives--;

        if (_lives <= 0)
        {
            Destroy(gameObject);
            _spawnerManager.OnPlayerDead();
        }
    }
}

 