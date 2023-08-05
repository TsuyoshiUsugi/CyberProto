using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.View
{
    public class FoodView : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        private Food _food;
        public Food Food => _food;

        public void SetFood(Food food)
        {
            _image.sprite = food.Icon;
            _food = food;
        }
    }
}