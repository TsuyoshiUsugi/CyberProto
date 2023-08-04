using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
  public class ScoreManager : MonoBehaviour
  {
    [SerializeField]
    private PopularityManager _popularityManager;

    public IReadOnlyReactiveProperty<int> Score => _score;
    private readonly IntReactiveProperty _score = new IntReactiveProperty(0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CaluculateScore()
    {

    }
  }
}