using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class HUD : MonoBehaviour
{

    [SerializeField] private float Points = 0;
    [SerializeField] private float MaxLives = 3;
    [SerializeField] private float CurrentLives = 3;
    [SerializeField] private TMP_Text textLife;
    [SerializeField] private TMP_Text timeLabel;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private float Gametimer;
    [SerializeField] private GameObject LoseScreen;


    [SerializeField] private float CurrentScore = default;

    public void AddScore(float amount)
    {
        CurrentScore += amount;
    }
    
    
    private void Update()
    {
        UpdateLife();
        UpdateTimer();
        UpdateScore();
    }

    void UpdateTimer()
    {
        Gametimer += Time.fixedTime;
        timeLabel.text = Gametimer.ToString("F1");
    }
    
    void UpdateScore()
    {
        textScore.text = CurrentScore.ToString();
    }
    
    void UpdateLife()
    {

        switch (CurrentLives)
        {
            case 0:
                LoseScreen.SetActive(true);
                break;
            case 1:
                textLife.text = CurrentLives + " Life";
                break;
            default:
                textLife.text = CurrentLives + " Lives";
                break;
        }
        
        
        
    }
    
    

    public void CloseApp()
    {
        Application.Quit();
    }

    public void Loadscene(string sceneString)
    {
        SceneManager.LoadScene(sceneString);
    }
    
    public void TakeLife()
    {
        CurrentLives--;
    }
    
    
}
