using UnityEngine;
using TMPro;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    public void ShowScore(int score)
    {
        _score.text = score.ToString();
    }
}
