using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    private int scores = 0;
    public int Score
    {
        get 
        {
            return scores;
        }
        set
        {
            scores = value;
        }
    }
}
