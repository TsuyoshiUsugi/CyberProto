using DG.Tweening;
using Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class OrderView : MonoBehaviour
    {
        [SerializeField]
        private FoodView _foodViewPrefab;

        [SerializeField]
        private Transform _foodContainer;

        [SerializeField]
        private Vector2 offset = Vector2.up;

        List<FoodView> _views = new List<FoodView>();

        [SerializeField]
        private GameObject successView;

        private void Awake()
        {
            successView.SetActive(false);
        }

        public void AddFood(Food food)
        {
            var view = Instantiate(_foodViewPrefab, _foodContainer);
            view.SetFood(food);
            view.gameObject.SetActive(true);
            _views.Add(view);
        }

        public void RemoveFood(int index)
        {
            if (_views[index] == null) return;
            var image = _views[index];
            image.transform.DOScale(0.0f, 0.1f)
                .SetEase(Ease.InBack)
                .SetLink(image.gameObject)
                .OnComplete(() => Destroy(image.gameObject));

            _views[index] = null;
        }

        public void OnCompleted()
        {
            _foodContainer.gameObject.SetActive(false);
            successView.SetActive(true);
        }

        public void SetPosition(Vector2 world)
        {
            transform.position = world + offset;
        }
    }

}