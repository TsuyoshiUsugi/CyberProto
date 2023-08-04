using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBgmPlayer
{
    void Play(AudioClip clip);
    void Stop();
}
