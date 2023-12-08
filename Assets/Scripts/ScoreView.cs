using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Base _botBase;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _botBase.ScoreChanged += WriteScore;
    }

    private void OnDisable()
    {
        _botBase.ScoreChanged -= WriteScore;
    }

    private void WriteScore(int score)
    {
        _score.text = score.ToString();
    }
}

