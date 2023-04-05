using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class UIController : MonoBehaviour
{

    private Label score;
    private Label scoreMini;
    private Button buttonRetry;
    private VisualElement defeatScreen;
    private int record;
    public GameObject player;
    private int currentScore = 0;

    void OnEnable()
    {
        var visualElements = GetComponent<UIDocument>().rootVisualElement;
        score = visualElements.Q<Label>("Score");
        scoreMini = visualElements.Q<Label>("ScoreMini");
        buttonRetry = visualElements.Q<Button>("Retry");
        defeatScreen = visualElements.Q<VisualElement>("GameOverScreen");

        buttonRetry.RegisterCallback<ClickEvent>(ev => OnDefeat());
        Doodle.isDefeat.AddListener(OnDefeatEvent);
        defeatScreen.visible = false;
    }
    void Start()
    {
        record = PlayerPrefs.GetInt("Record", 0);
    }

    void Update()
    {
        if (player.transform.position.y > currentScore)
        {
            currentScore = Convert.ToInt32(player.transform.position.y);
        }

        score.text = "Score: " + currentScore.ToString() + " | Record: " + record.ToString();
        scoreMini.text = "Score: " + currentScore.ToString() + " | Record: " + record.ToString();
    }

    public void OnDefeat()
    {
        if (record < currentScore)
        {
            PlayerPrefs.SetInt("Record", currentScore);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void OnDefeatEvent()
    {
        defeatScreen.visible = true;
    }
}
