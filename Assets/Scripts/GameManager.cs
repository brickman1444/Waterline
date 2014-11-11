using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GUIText timer;

    public static GameManager shittyInstance = null;

    float initialTime = 0;
    float finalTime = 0;
    bool isGameOver = false;

    public GUIText gameOverText;

    void Awake()
    {
        shittyInstance = this;
    }

    // Use this for initialization
    void Start()
    {
        initialTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {

        if (!isGameOver)
        {
            float displayTime = Time.realtimeSinceStartup - initialTime;
            timer.text = string.Format("{0:n1}{1}", displayTime, "s");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                Application.LoadLevel("menu");
            }
        }
	}

    public void EndGame()
    {
        if (!isGameOver)
        {
            finalTime = Time.realtimeSinceStartup;
            Time.timeScale = 0;
            isGameOver = true;
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over\nYou survived for " + string.Format("{0:n1}", finalTime - initialTime) + " seconds\nPress Enter to return to menu.";
        }
    }
}
