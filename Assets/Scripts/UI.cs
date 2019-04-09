using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public Button start;
    public Button main;
    public Button quit;
    public Button score;

    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        main.onClick.AddListener(() => SceneManager.LoadScene("titlescreen"));
        quit.onClick.AddListener(() => Application.Quit());
        score.onClick.AddListener(() => SceneManager.LoadScene("highscore"));
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
