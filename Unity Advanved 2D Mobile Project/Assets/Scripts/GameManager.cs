using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _scoreText;
    [SerializeField]
    Button _button;
    [SerializeField]
    float _score = 5;
    float _totalScore;
    public void Update()
    {
        if(_totalScore >= 15)
        {
            var newPos = new Vector3(_button.transform.position.x, _button.transform.position.x + 5, 0);
            _button.transform.position = newPos;
        }
    }
    void UpdateScore()
    {
        _scoreText.text = $"Score: {_totalScore}";
    }
    public void OnScoreButtonPressed()
    {
        _totalScore += _score;
        UpdateScore();
    }
}
