using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject cameraM;
    public Transform inGameCameraPos;
    public static Action onGameStarted;
    private bool isGameStarted;
    private float currentTimeScale;
    private int score;
    private int money;
    private int gameTime=60;
    private float sec;
        private void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
        currentTimeScale = Time.timeScale;
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else
        {
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.Save();
        }
    }
    private void Start()
    {
        UIManager.instance.ShowMoney(money.ToString());
    }
    private void Update()
    {

        if (isGameStarted)
        {
            UIManager.instance.ShowTime(gameTime.ToString());
            if (sec >= 1)
            {
                sec = 0;
                gameTime--;

            }
            else
            {
                sec += Time.deltaTime;
            }
            //score += 1;
            UIManager.instance.ShowScore(score.ToString());
        }
        if (gameTime==0)
        {
            EndGame();
        }
    }
    public void IncreaseScore()
    {
        score++;
    }
    public void StartGame()
    {
        gameTime = 60;
        isGameStarted = true;
        onGameStarted?.Invoke();
        Time.timeScale = 1f;
        PlayerManager.instance.SetAimAnim();
        cameraM.transform.DOMove(inGameCameraPos.position, 2f);
        cameraM.transform.DORotateQuaternion(inGameCameraPos.rotation, 2f);
    }
    public void PauseGame()
    {
        isGameStarted = false;
        Time.timeScale = 0f;
    }
    public void UnPauseGame()
    {
        isGameStarted = true;
        Time.timeScale = currentTimeScale;
    }
    public void EndGame()
    {
        if (isGameStarted)
        {
            isGameStarted = false;
            money = score;
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + score);
            Debug.Log(PlayerPrefs.GetInt("Money"));
            PlayerPrefs.Save();
            CheckBestScore();
            UIManager.instance.EndGame();
        }
    }
    private void CheckBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            int tempBestScore = PlayerPrefs.GetInt("BestScore");
            if (tempBestScore > score)
            {
                UIManager.instance.ShowBestScore(tempBestScore.ToString());
            }
            else
            {
                UIManager.instance.ShowBestScore(score.ToString());
                PlayerPrefs.SetInt("BestScore", score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            UIManager.instance.ShowBestScore(score.ToString());
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
    }
    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
