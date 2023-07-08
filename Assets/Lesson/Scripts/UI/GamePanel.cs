using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Lesson.Scripts
{
    public class GamePanel : MonoBehaviour, IInitializable
    {
        [SerializeField] private TextMeshProUGUI _coinsLabel;
        
        private CoinsData _coinsData;
        private ILocalization _localization;

        [Inject]
        private void Construct(CoinsData coinsData, ILocalization localization)
        {
            _coinsData = coinsData;
            _localization = localization;
        }

        public void Initialize()
        {
            AddListeners();
        }

        private void AddListeners()
        {
            _coinsData.Coins.Subscribe(_ => UpdateInfo());
        }

        private void UpdateInfo()
        {
            _coinsLabel.text = _localization.Translate("coins", _coinsData.Coins.Value);
        }
    }
}
