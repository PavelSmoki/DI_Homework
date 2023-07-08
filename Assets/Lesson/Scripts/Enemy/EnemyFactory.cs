using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Lesson
{
    [UsedImplicitly]
    public class EnemyFactory
    {
        private const float _border = 24.0f;
        private readonly DiContainer _container;
        private readonly List<EnemyData> _enemiesData;

        public EnemyFactory(DiContainer container, List<EnemyData> enemiesData)
        {
            _container = container;
            _enemiesData = enemiesData;
        }

        public void Create()
        {
            var enemyData = _enemiesData[Random.Range(0, _enemiesData.Count)];
            var enemy = Object.Instantiate(enemyData.Prefab).GetComponent<Enemy>();
            enemy.SetEnemyData(enemyData);
            enemy.transform.position = new Vector3( 
                Random.Range(-_border, _border),
                0.5f,
                Random.Range(-_border, _border)
            );
            _container.Inject(enemy);
        }
    }
}