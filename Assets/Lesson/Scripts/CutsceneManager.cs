using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Lesson
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _playableDirector;
        private bool _sceneSkipped;
        private Enemy[] _enemies;

        private void Start()
        {
            _enemies = FindObjectsOfType<Enemy>();
        }

        private void Update()
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !_sceneSkipped)
            {
                _playableDirector.time = 7.1667f;
                _sceneSkipped = true;
            }
        }

        public void StartCutscene()
        {
            foreach (var enemy in _enemies)
            {
                enemy.SetEnemySpeedForCutscene();
            }
        }

        public void EndCutscene()
        {
            foreach (var enemy in _enemies)
            {
                enemy.ReturnEnemySpeedAfterCutscene();
            }
        }
    }
}
