﻿using System;

namespace Utils
{
    public static class EventHub
    {
        public static event Action gameOvered;
        public static event Action gameStarted;
        public static event Action<bool> gamePaused;
        public static event Action<float> scoreChanged;
        public static event Action<int> healthChanged;
        public static event Action<int> bulletsChanged;
        public static event Action<int> coinsChanged;
        public static event Action<int> playerModelChanged;
        public static event Action audioSettingsChanged;
        public static event Action bonusRocketPickedUp;

        public static void OnGameOvered()
        {
            gameOvered?.Invoke();
        }
        
        public static void OnGamePaused(bool paused)
        {
            gamePaused?.Invoke(paused);
        }
        
        public static void OnScoreChanged(int score)
        {
            scoreChanged?.Invoke(score);
        }
        
        public static void OnHealthChanged(int health)
        {
            healthChanged?.Invoke(health);
        }
        
        public static void OnBulletsChanged(int bullets)
        {
            bulletsChanged?.Invoke(bullets);
        }

        public static void OnGameStarted()
        {
            gameStarted?.Invoke();
        }

        public static void OnAudioSettingsChanged()
        {
            audioSettingsChanged?.Invoke();
        }

        public static void OnCoinsChanged(int coins)
        {
            coinsChanged?.Invoke(coins);
        }
        
        public static void OnPlayerModelChanged(int model)
        {
            playerModelChanged?.Invoke(model);
        }

        public static void OnBonusRocketPickUp()
        {
            bonusRocketPickedUp?.Invoke();
        }
    }
}