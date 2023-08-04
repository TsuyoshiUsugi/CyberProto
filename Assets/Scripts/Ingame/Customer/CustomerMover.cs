using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Game
{
    public class CustomerMover : MonoBehaviour
    {
        private enum State
        {
            Walk,
            Exit
        }

        [SerializeField]
        private State _state;
        [SerializeField]
        private float _walkSpeed = 1.0f;

        private void Start()
        {
            var customer = GetComponent<Customer>();
            customer.ProvideCompleted
                .Subscribe(_ => _state = State.Exit);
        }

        private void Update()
        {
            switch (_state)
            {
                case State.Walk:
                    transform.position += Vector3.right * _walkSpeed * Time.deltaTime;
                    break;

                case State.Exit:
                    transform.position += Vector3.up * _walkSpeed * Time.deltaTime;
                    break;
            }
        }
    }

}