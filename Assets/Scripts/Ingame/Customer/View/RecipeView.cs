using Game;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.View
{
    public class RecipeView : MonoBehaviour
    {
        private Food _currentFood = null;

        [SerializeField]
        private Transform _container;

        [SerializeField]
        private Image _imagePrefab;

        [SerializeField]
        GraphicRaycaster _raycaster;

        private Image[] _imageCache;

        private List<RaycastResult> _raycastResults = new List<RaycastResult>(8);

        private Camera mainCamera;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _imageCache = new Image[5];
            for (int i = 0; i < _imageCache.Length; i++)
            {
                _imageCache[i] = Instantiate(_imagePrefab, _container);
                _imageCache[i].gameObject.SetActive(false);
            }

            _rectTransform = transform as RectTransform;
            _container.gameObject.SetActive(false);
        }

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            var eventSystem = EventSystem.current;
            if (eventSystem == null) return;

            var evt = new PointerEventData(eventSystem);
            evt.position = Input.mousePosition;

            _raycastResults.Clear();
            _raycaster.Raycast(evt, _raycastResults);

            // パフォーマンスが最悪そう
            Food food = null;
            for (int i = 0; i < _raycastResults.Count; i++)
            {
                if (_raycastResults[i].gameObject.TryGetComponent<FoodView>(out var foodView))
                {
                    food = foodView.Food;
                    break;
                }
            }

            SetFood(food);

            if (_currentFood != null)
            {
                _rectTransform.position = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        public void SetFood(Food food)
        {
            if (_currentFood == food) return;
            _currentFood = food;

            if (food == null)
            {
                _container.gameObject.SetActive(false);
                return;
            }

            Ingredient[] ingredients = food.Ingredients;
            for (int i = 0; i < _imageCache.Length; i++)
            {
                if (i >= ingredients.Length)
                {
                    _imageCache[i].gameObject.SetActive(false);
                    continue;
                }

                _imageCache[i].sprite = ingredients[i].Icon;
                _imageCache[i].gameObject.SetActive(true);
            }
            _container.gameObject.SetActive(true);
        }
    }

}