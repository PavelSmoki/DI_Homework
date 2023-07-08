using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Lesson
{
    public class CoinFactory
    {

        private const float _border = 22.0f;
        private readonly DiContainer _container;
        private readonly GameObject _coinPrefab;

        public CoinFactory(DiContainer container, [Inject(Id = "coin")] GameObject coinPrefab)
        {
            _container = container;
            _coinPrefab = coinPrefab;
        }

        public void Create()
        {
            var coin = Object.Instantiate(_coinPrefab,
                new Vector3(
                    Random.Range(-_border, _border),
                    2f,
                    Random.Range(-_border, _border)),
                Quaternion.identity).GetComponent<Coin>();
            _container.Inject(coin);
        }
    }
}