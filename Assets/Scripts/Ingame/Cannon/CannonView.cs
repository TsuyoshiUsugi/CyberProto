using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class CannonView : MonoBehaviour
    {

        public bool Active { get; private set; }
        [SerializeField] private SpriteRenderer _arrowRenderer;
        [SerializeField] private SpriteRenderer _cannonRenderer;

        /// <summary>
        /// �^�b�v�����ǂ���
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
                _arrowRenderer.enabled = true;
                SetCannonDirection(Vector2.up);
            }
        }

        /// <summary>
        /// �C�g�Ɩ��̌����ƃT�C�Y���X�V����
        /// </summary>
        /// <param name="vector"></param>

        public void SetDirectionAndScale(Vector2 vector)
        {
            _arrowRenderer.transform.rotation = Quaternion.Euler(0, 0, GetVectorDegree(vector));
            _cannonRenderer.transform.rotation = Quaternion.Euler(0, 0, GetVectorDegree(vector));
            var scale = vector.magnitude;
            SetArrowScale(scale);
        }

        /// <summary>
        /// ���̌�����ύX����
        /// </summary>
        /// <param name="vector"></param>
        public void SetArrowDirection(Vector2 vector)
        {
            _arrowRenderer.transform.rotation = Quaternion.Euler(0, 0, GetVectorDegree(vector));
        }


        /// <summary>
        /// ���̑傫����ύX����
        /// </summary>
        /// <param name="scale"></param>
        public void SetArrowScale(float scale)
        {
            _arrowRenderer.transform.localScale = new Vector3(scale, scale, scale);
        }

        /// <summary>
        /// �C�g�̌�����ύX����
        /// </summary>
        /// <param name="vector"></param>
        public void SetCannonDirection(Vector2 vector)
        {
            _cannonRenderer.transform.rotation = Quaternion.Euler(0, 0, GetVectorDegree(vector));
        }
        /// <summary>
        /// vector��degree�ɕϊ�����
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        private float GetVectorDegree(Vector2 vector)
        {
            var rad = Mathf.Atan2(vector.y, vector.x);
            return rad * Mathf.Rad2Deg;
        }
    }
}
