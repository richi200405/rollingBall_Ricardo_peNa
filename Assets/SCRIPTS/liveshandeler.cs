using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liveshandeler : MonoBehaviour
{
    private int lives = 0;
    public int live
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }
}
