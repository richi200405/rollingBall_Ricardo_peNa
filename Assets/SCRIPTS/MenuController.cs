using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject finaltext;

    public TextMeshProUGUI[] counttext;
    public TextMeshProUGUI[] livestext;

   

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
