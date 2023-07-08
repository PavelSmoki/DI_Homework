using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Lesson
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private ICharacter _character;
        private EnemyData _enemyData;

        private float _actualSpeed;

        [Inject]
        private void Construct(ICharacter character)
        {
            _character = character;
        }

        public void SetEnemyData(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        private void Update()
        {
            var distance = Vector3.Distance(transform.position, _character.GetCurrentPosition());
            if (distance <= _enemyData.ViewRange)
            {
                _agent.SetDestination(_character.GetCurrentPosition());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Instantiate(_enemyData.Particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

        public void SetEnemySpeedForCutscene()
        {
            _agent.speed = 0;
        }

        public void ReturnEnemySpeedAfterCutscene()
        {
            _agent.speed = _enemyData.Speed;
        }
    }
}