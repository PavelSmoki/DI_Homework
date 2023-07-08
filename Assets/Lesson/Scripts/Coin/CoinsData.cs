using UniRx;
using UnityEngine;

namespace Lesson
{
    public class CoinsData : ScriptableObject
    {
        public IReactiveProperty<int> Coins { get; } = new IntReactiveProperty(0);

    }
}
