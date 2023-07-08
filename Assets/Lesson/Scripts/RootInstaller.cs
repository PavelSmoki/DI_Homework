using System.Collections.Generic;
using Lesson.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Lesson
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private GamePanel _gamePanelObject;
        [SerializeField] private Character _character;
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private GameOverPanel _gameOverPanel;
        [SerializeField] private List<EnemyData> _enemiesData;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _bulletPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ILocalization>().To<UnityLocalization>().AsSingle().NonLazy();

            Container.Bind<GameObject>().WithId("coin").FromInstance(_coinPrefab);
            Container.Bind<Camera>().WithId("mainCamera").FromInstance(_camera);
            Container.Bind<GameObject>().WithId("bullet").FromInstance(_bulletPrefab);
            
            Container.Bind<ICharacter>().FromInstance(_character);
            
            Container.Bind<CoinsData>().AsSingle();
            Container.Bind<CoinFactory>().AsSingle().NonLazy();
            Container.Bind<EnemyFactory>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();

            Container.BindInterfacesTo<GameplayController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<GamePanel>().FromInstance(_gamePanelObject);
            
            Container.Bind<GameOverPanel>().FromInstance(_gameOverPanel);
            Container.Bind<GameSettings>().FromInstance(_gameSettings);
            
            foreach (var enemyData in _enemiesData)
            {
                Container.Bind<EnemyData>().FromInstance(enemyData);
            }
        }    
    }
}
