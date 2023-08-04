using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Game
{
  public class GameMetricsPresenter : MonoBehaviour
  {
    [SerializeField]
    private ScoreManager _soreModel;
    [SerializeField]
    private PopularityManager _populalityModel;
    [SerializeField]
    private GameMetricsView _scoreView;

    // Start is called before the first frame update
    void Start()
    {
      _soreModel.Score
      .Subscribe(x =>
      {
        _scoreView.SetScore(x);
      }).AddTo(this);

      _populalityModel.PopularityScore
      .Subscribe(x =>
      {
        _scoreView.SetPopulality(x);
      }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
  }
}
