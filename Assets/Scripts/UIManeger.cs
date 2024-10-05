using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _player;

    void Start()
    {
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScore()
    {
        Player player = _player.transform.GetComponent<Player>();
        _scoreText.text = "Score: " + player.GetScore;
    }
}
