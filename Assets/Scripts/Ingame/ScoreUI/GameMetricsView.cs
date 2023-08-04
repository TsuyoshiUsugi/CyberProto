using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

namespace Game
{
  public class GameMetricsView : MonoBehaviour
  {
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _populalityText;
    [SerializeField]
    private TextMeshProUGUI _timerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore(int score)
    {
      _scoreText.text = score.ToString();
    }

    public void SetPopulality(float populality)
    {
      _populalityText.text = populality.ToString("F1");
    }

    public void Settimer(float time)
    {
      _timerText.text = time.ToString("F2");
    }
  }
}