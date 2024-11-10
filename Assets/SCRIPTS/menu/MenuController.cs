using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject finaltext;

    public TextMeshProUGUI[] counttext;
    public TextMeshProUGUI[] livestext;
    public GameObject[] PauseUI;
    


    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
    }


    public void Pause() 
    {
        Time.timeScale = 0;
        PauseUI[0].SetActive(false);
        PauseUI[1].SetActive(true);
    }


    public void UnPause()
    {
        Time.timeScale = 1;
        PauseUI[0].SetActive(true);
        PauseUI[1].SetActive(false);
    }




    public void LoseGame() 
    {
        finaltext.SetActive(true);
        finaltext.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game Over";
        
       
    }

    public void WinGame()
    {
        finaltext.SetActive(true);
        finaltext.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win";
    }


    public void addCounttext(int playerindex, int count) 
    {
        counttext[playerindex].text = "count: " + count.ToString();
    }

    public void addlivestext(int playerindex, int lives)
    {
        livestext[playerindex].text = "lives: " + lives.ToString();
    }
}
