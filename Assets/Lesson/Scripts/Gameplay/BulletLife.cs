using System.Collections;
using UnityEngine;

namespace Lesson
{
    public class BulletLife : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

        private void Start()
        {
            StartCoroutine(nameof(Life));
        }

        private IEnumerator Life()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }
    }
}
