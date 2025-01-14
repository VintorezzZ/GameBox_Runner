﻿using System;
using Cinemachine;
using MyGame.Managers;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using Utils;
using Views;

    public class GameManager : SingletonBehaviour<GameManager>
    {
        public CinemachineVirtualCamera virtualCamera;
        public Camera mainCamera;
        public Volume postProcessVolume;
        public UniversalRenderPipelineAsset lowQualityGraphic;
        public UniversalRenderPipelineAsset highQualityGraphic;

        private void Awake()
        {
#if !UNITY_EDITOR
            Application.targetFrameRate = 120;
#endif
            InitializeSingleton();

            EventHub.gameOvered += OnGameOver;

            SceneManager.sceneLoaded += (scene, mode) =>
            {
                if (scene.name == "Gameplay")
                {
                    InitGameScene(scene);
                }
            };

            SceneManager.sceneUnloaded += scene =>
            {
                if (scene.name == "Gameplay")
                {
                    LoadGameScene();
                }
            };
            
            //PlayerPrefs.DeleteAll();
        }
        private void InitGameScene(Scene scene)
        {
            ViewManager.Show<MainMenuView>();
            SceneManager.SetActiveScene(scene);
            WorldBuilder.Instance.Init(0);
        }

        private void OnGameOver()
        {
            ViewManager.Show<GameOverView>();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
  
        public void QuitGame()
        {
            Application.Quit();
        }

        public void RestartGame()
        {
            ViewManager.Show<LoadingScreenView>();
            SoundManager.Instance.PreRestartGame();
            SceneManager.UnloadSceneAsync("Gameplay");
        }

        public void StartGame()
        {
            EventHub.OnGameStarted();
            Time.timeScale = 1;
        }

        public void UnpauseGame()
        {
            
        }
        
        public void LoadGameScene()
        {
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
        }
    }

