using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    // âÊñ äOÇ…èoÇΩéûÇ…Ç®ãqólÇè¡Ç∑èàóù
    public class CustomerDestroyer : MonoBehaviour
    {
        private Camera _mainCamera;

        [Flags]
        private enum Direction
        {
            None = 0b0000,
            Left = 0b0001,
            Right = 0b0010,
            Top = 0b0100,
            Bottom = 0b1000,
        }

        [SerializeField]
        private Direction destroyDirection;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector3 viewport = _mainCamera.WorldToViewportPoint(transform.position);

            if (IsEnable(Direction.Left)
                && viewport.x < -0.1f) 
            {
                Destroy();
            }
            else if (IsEnable(Direction.Right)
                && viewport.x > 1.1f)
            {
                Destroy();
            }
            else if (IsEnable(Direction.Top)
                && viewport.y > 1.1f)
            {
                Destroy();
            }
            else if (IsEnable(Direction.Bottom)
                && viewport.x < -0.1f)
            {
                Destroy();
            }
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }

        private bool IsEnable(Direction direction)
        {
            return (destroyDirection & direction) != 0;
        }
    }

}