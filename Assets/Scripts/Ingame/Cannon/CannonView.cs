﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class CannonView : MonoBehaviour
    {

        public bool Active { get; private set; }
        [SerializeField] private SpriteRenderer _arrowRenderer;
        [SerializeField] private SpriteRenderer _cannonRenderer;

        private void Start()
        {
            _arrowRenderer.enabled = false;
        }

        /// <summary>
        /// タップ中かどうか
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            if (active)
            {
                _arrowRenderer.enabled = true;
            }
            else
            {
                _arrowRenderer.enabled = false;
                SetCannonDirection(Vector2.down);
            }
        }

        /// <summary>
        /// 砲身と矢印の向きとサイズを更新する
        /// </summary>
        /// <param name="vector"></param>

        public void SetDirectionAndScale(Vector2 vector)
        {
            _arrowRenderer.transform.rotation = Quaternion.Euler(0, 0, GetVectorDegree(vector));
            _cannonRenderer.transform.rotation = Quaternion.Euler(0, 0, GetVectorDegree(vector));
            var scale = vector.magnitude * 0.001f;
            SetArrowScale(scale);
        }

        /// <summary>
        /// 矢印の向きを変更する
        /// </summary>
        /// <param name="vector"></param>
        public void SetArrowDirection(Vector2 vector)
        {
            _arrowRenderer.transform.rotation = Quaternion.Euler(0, 0, GetVectorDegree(vector));
        }


        /// <summary>
        /// 矢印の大きさを変更する
        /// </summary>
        /// <param name="scale"></param>
        public void SetArrowScale(float scale)
        {
            _arrowRenderer.transform.localScale = new Vector3(scale * 0.75f, scale, scale);
        }

        /// <summary>
        /// 砲身の向きを変更する
        /// </summary>
        /// <param name="vector"></param>
        public void SetCannonDirection(Vector2 vector)
        {
            _cannonRenderer.transform.rotation = Quaternion.Euler(0, 0, GetVectorDegree(vector));
        }
        /// <summary>
        /// vectorをdegreeに変換する
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        private float GetVectorDegree(Vector2 vector)
        {
            var rad = Mathf.Atan2(vector.y, vector.x);
            return rad * Mathf.Rad2Deg + 90;
        }
    }
}
