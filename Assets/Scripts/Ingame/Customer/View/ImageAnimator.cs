using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class ImageAnimator : MonoBehaviour
    {
        [SerializeField]
        Image targetImage;

        [SerializeField]
        Sprite[] sprites = new Sprite[0];

        [SerializeField]
        float frameTime = 0.1f;

        private bool enable = false;

        CancellationTokenSource cts;

        private void OnEnable()
        {
            enable = true;
            cts = new CancellationTokenSource();
            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, this.GetCancellationTokenOnDestroy());
            AnimationAsycn(linkedCts.Token).Forget();
        }

        private void OnDisable()
        {
            cts?.Cancel();
        }

        private async UniTask AnimationAsycn(CancellationToken ct)
        {
            int index = 0;
            while (!ct.IsCancellationRequested)
            {
                targetImage.sprite = sprites[index];
                index = (index + 1) % sprites.Length;
                await UniTask.Delay((int)(frameTime * 1000));
            }
        }
    }

}