using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lesson
{
    [UsedImplicitly]
    public class GameplayController : IInitializable, ITickable, IDisposable
    {
        private readonly ICharacter _character;
        private readonly CoinsData _coinsData;
        private readonly EnemyFactory _enemyFactory;
        private readonly CoinFactory _coinFactory;
        private readonly GameSettings _gameSettings;
        private readonly GameOverPanel _gameOverPanel;
        private readonly InputHandler _inputHandler;

        private TextMeshProUGUI _gameOverLabel;
        private TextMeshProUGUI _buttonLabel;
        private Button _button;
        private bool _dead;

        public GameplayController(ICharacter character, CoinsData coinsData, EnemyFactory enemyFactory,
            CoinFactory coinFactory, GameSettings gameSettings, GameOverPanel gameOverPanel, InputHandler inputHandler)
        {
            _character = character;
            _coinsData = coinsData;
            _enemyFactory = enemyFactory;
            _coinFactory = coinFactory;
            _gameSettings = gameSettings;
            _gameOverPanel = gameOverPanel;
            _inputHandler = inputHandler;
        }

        public void Initialize()
        {
            Time.timeScale = 1;

            _character.Setup(GameOver);
            _gameOverPanel.Setup();
            _inputHandler.OnClicked += OnClicked;

            for (var i = 0; i < _gameSettings.EnemyCount; i++)
            {
                _enemyFactory.Create();
            }

            for (var i = 0; i < _gameSettings.CoinsToCollect; i++)
            {
                _coinFactory.Create();
            }
        }


        public void Tick()
        {
            if (_coinsData.Coins.Value == _gameSettings.CoinsToCollect && !_dead)
            {
                GameOver();
            }
        }

        private void OnClicked(Vector3 pos)
        {
            _character.MoveTo(pos);
        }

        private void GameOver()
        {
            _dead = true;
            _gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void Dispose()
        {
            _inputHandler.OnClicked -= OnClicked;
        }
    }
}