using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;

    private Player _player;

    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _LivesImg;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _scoreText.text = "Score: " + 0;
        _player = GameObject.Find("Player").GetComponent<Player>();
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }
    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }
    IEnumerator GameOverTextFlip()
    {
        while (true) {
            _gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.6f);
        }
    }
    private void GameOverSequence()
    {
        StartCoroutine(GameOverTextFlip());
        _restartText.gameObject.SetActive(true);
        _gameManager.GameOver();
    }
}
