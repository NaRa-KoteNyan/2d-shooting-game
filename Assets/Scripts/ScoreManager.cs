using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreLabel;
    private Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(manager.IsPlaying())
        {
          GameObject player = GameObject.FindGameObjectWithTag("Player");
          int score = player.GetComponent<PlayerController>().score;
          scoreLabel.text = score.ToString();
        }
        
    }
}
