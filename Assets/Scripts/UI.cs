using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Animator PlayerAnimator;

    private bool StartupOccured = false;
    private bool GameStarted = false;

    private float Score;

    [SerializeField] 
    private TMP_Text ScoreLabel;

    [SerializeField]
    private GameObject Menu;

    [SerializeField]
    private TMP_Text ScoresRecord;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore") && PlayerPrefs.HasKey("PrevScore"))
        {
            ScoresRecord.SetText("High Score: " + PlayerPrefs.GetInt("HighScore") + "\nPrevious Score: " + PlayerPrefs.GetInt("PrevScore"));
        }
        else
        {
            ScoresRecord.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!StartupOccured)
        {
            Platform[] platforms = FindObjectsOfType<Platform>();
            foreach (Platform p in platforms)
            {
                p.StopMoving();
            }
            StartupOccured = true;
        }

        if (GameStarted)
        {
            Score += Time.deltaTime;
            ScoreLabel.SetText("Time Alive: " + Mathf.RoundToInt(Score));
        }
    }

    public void StartGame()
    {
        Platform[] platforms = FindObjectsOfType<Platform>();
        foreach (Platform p in platforms)
        {
            p.StartMoving();
        }
        Menu.SetActive(false);
        PlayerAnimator.SetTrigger("Start");

        GameStarted = true;
    }

    public int GetScore()
    {
        return Mathf.RoundToInt(Score);
    }
}
