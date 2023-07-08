using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Zenject;

namespace Lesson
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _gameOverLabel;
        [SerializeField] private TextMeshProUGUI _buttonLabel;
        private Button _button;
        
        private ILocalization _localization;

        [Inject]
        private void Construct(ILocalization localization)
        {
            _localization = localization;
        }

        public void Setup()
        {
            _gameOverLabel.text = _localization.Translate("game.over.label");
            _buttonLabel.text = _localization.Translate("restart.button");
        }

        public void OnButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
