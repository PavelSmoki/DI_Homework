using UnityEngine;

namespace Lesson
{
    [CreateAssetMenu(menuName = "Tools/Game Settings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField] public int EnemyCount { get; private set; }
        [field: SerializeField] public int CoinsToCollect { get; private set; }
    }
}
