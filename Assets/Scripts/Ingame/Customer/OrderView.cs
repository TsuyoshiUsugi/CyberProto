using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class OrderView : MonoBehaviour
    {
        [SerializeField]
        private Image _foodImage;
        [SerializeField]
        private Vector2 offset = Vector2.up;

        List<Image> _images = new List<Image>();

        public void AddFood(Food food)
        {
            var image = Instantiate(_foodImage, transform);
            image.sprite = food.Icon;
            image.gameObject.SetActive(true);
            _images.Add(image);
        }

        public void RemoveFood(int index)
        {
            if (_images[index] == null) return;
            var image = _images[index];
            image.rectTransform.DOScale(0.0f, 0.1f)
                .SetEase(Ease.InBack)
                .SetLink(image.gameObject)
                .OnComplete(() => Destroy(image.gameObject));

            _images[index] = null;
        }

        public void OnCompleted()
        {
            Debug.Log("‚É‚±‚¿‚á‚ñ•\Ž¦");
        }

        public void SetPosition(Vector2 world)
        {
            transform.position = world + offset;
        }
    }

}