using System;
using Lesson.Scripts;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Lesson
{
    public class Character : MonoBehaviour, ICharacter
    {
        // [SerializeField] private float _speed;
        [SerializeField] private NavMeshAgent _agent;

        // private const float Border = 24.0f;

        private  CoinsData _coinsData;
        private Action _death;

        [Inject]
        private void Construct(CoinsData coinsData)
        {
            _coinsData = coinsData;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin"))
            {
                _coinsData.Coins.Value++;
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                _death.Invoke();
            }
        }

        public void Setup(Action death)
        {
            _death = death;
        }

        public Vector3 GetCurrentPosition() => transform.position;

        public void MoveTo(Vector3 pos)
        {
            _agent.SetDestination(pos);
        }

        /*private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * (-_speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * (_speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * (_speed * Time.deltaTime));
            }

            if (transform.position.x < -Border)
            {
                transform.position = new Vector3(-Border, transform.position.y, transform.position.z);
            }

            if (transform.position.x > Border)
            {
                transform.position = new Vector3(Border, transform.position.y, transform.position.z);
            }

            if (transform.position.z > Border)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Border);
            }

            if (transform.position.z < -Border)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -Border);
            }
        }*/
    }
}