using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMgr : MonoBehaviour
{
    
    int score = 0;
    Text text;
    public void Start()
    {
        text = GetComponent<Text>();
        text.text = "Score : " + score;
    }

    public void Update()
    {
        text.text = "Score : " + GameManager.Score;
    }
}
