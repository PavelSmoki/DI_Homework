using UnityEngine;

namespace Lesson
{
    public class Coin : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(Vector3.up, 45 * Time.deltaTime);
        }
    }
}
