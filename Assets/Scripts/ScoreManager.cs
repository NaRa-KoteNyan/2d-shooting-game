using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int score = player.GetComponent<PlayerController>().score;
        scoreLabel.text = score.ToString();
    }
}
