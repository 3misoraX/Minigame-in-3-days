using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public TMP_Text scoreCounter;
    public TMP_Text fScore;
    public int score = 0;
    public float time = 0f;
    public GameObject gm;
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    //add and show score
    public void AddScore()
    {
        score++;
        scoreCounter.text = "Score: " + score;
    }

    //Show final score and game over screen
    public void ShowFinal()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gm.SetActive(true);
        fScore.text = "Score: " + score + "\nTime survived: \n" + time;
    }
}
