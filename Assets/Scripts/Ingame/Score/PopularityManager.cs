using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
  public class PopularityManager : MonoBehaviour
  {
    public IReadOnlyReactiveProperty<float> PopularityScore => _popularityScore;
    private readonly FloatReactiveProperty _popularityScore = new FloatReactiveProperty(0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
  }
}
