using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 5.0f;
    private float _fireRate = 0.5f;
    private float _nextTime = 0f;

    [SerializeField]
    private int _lives = 3;

    // Intantiate
    private SpawnerManager _spawnerManager;

    [SerializeField]
    private GameObject _lazerPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    //Power Ups
    private float _powerUpDuration = 5f;
    private bool _isTripleShotActive = false;
    private bool _isShieldActive = false;

    [SerializeField]
    private GameObject _shieldVisualization;

    private int _score = 0;



    void Start()
    {
        _spawnerManager = GameObject.Find("Spawner_Manager").GetComponent<SpawnerManager>();
        transform.position = new Vector3(0, 0, 0);
        _shieldVisualization.SetActive(false);
    }  
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new(horizontalInput, verticalInput, 0);

        transform.Translate(_speed * Time.deltaTime * direction);
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
        _nextTime = Time.time + _fireRate;

        if (_isTripleShotActive == true)
        {
            Vector3 lazerOffSet = new(transform.position.x -0.5f, transform.position.y, 0);
            Instantiate(_tripleShotPrefab, lazerOffSet, Quaternion.identity);
        }

        else
        {
            Vector3 lazerOffSet = new(transform.position.x, transform.position.y + 1.05f, 0);
            Instantiate(_lazerPrefab, lazerOffSet, Quaternion.identity);
        }
    }
    public void TakeDamage()
    {   
        if (_isShieldActive == true)
        {
            _isShieldActive = false;
            _shieldVisualization.SetActive(false);
            return;
        }

        _lives--;

        if (_lives <= 0)
        {
            Destroy(gameObject);
            _spawnerManager.OnPlayerDead();
        }
    }
    public void TripleShot()
    {
        StartCoroutine(ActiveTripleShot());
    }
    IEnumerator ActiveTripleShot()
    {
        _isTripleShotActive = true;
        yield return new WaitForSeconds(_powerUpDuration);
        _isTripleShotActive = false;
    }
    public void SpeedBoost()
    {
        StartCoroutine(ActiveSpeedBoost());
    }
    IEnumerator ActiveSpeedBoost()
    {
        _speed = 10f;
        yield return new WaitForSeconds(_powerUpDuration);
        _speed = 5f;
    }
    public void Shield()
    {
        _isShieldActive = true;
        _shieldVisualization.SetActive(true);

    }
    public void AddScore(int points)
    {
        _score += points;
    }
    public int GetScore()
    {
        return _score;
    }
}
    