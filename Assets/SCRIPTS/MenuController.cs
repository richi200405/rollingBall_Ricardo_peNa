using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI[] counttext; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCounttext(int playerindex, int count) 
    {
        counttext[playerindex].text = "count: " + count.ToString();
    }

}
