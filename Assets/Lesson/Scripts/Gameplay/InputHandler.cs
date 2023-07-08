using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Lesson
{
    public class InputHandler : ITickable
    {
        private const string LayerName = "Ground";

        private readonly Camera _camera;
        private readonly ICharacter _character;
        private readonly GameObject _bulletPrefab;

        public Action<Vector3> OnClicked;

        public InputHandler([Inject(Id = "mainCamera")] Camera camera, ICharacter character,
            [Inject(Id = "bullet")] GameObject bulletPrefab)
        {
            _camera = camera;
            _character = character;
            _bulletPrefab = bulletPrefab;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                var mask = LayerMask.GetMask(LayerName);
                if (Physics.Raycast(ray, out var hitInfo, 100, mask))
                {
                    OnClicked?.Invoke(hitInfo.point);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    var bullet = Object.Instantiate(_bulletPrefab, _character.GetCurrentPosition(),
                        Quaternion.identity);
                    bullet.transform.LookAt(hitInfo.point);
                    bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);
                }
            }
        }
    }
}