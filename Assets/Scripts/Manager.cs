using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update

    //Playerプレハブ
    public GameObject player;

    //タイトル
    public GameObject title;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム中ではない　かつ　Xキーが押されたらゲームスタート。
        if(IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
        }
    }

    void GameStart()
    {
        //ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する。
        title.SetActive(false);
        GameObject playerObject = Instantiate(player,player.transform.position,player.transform.rotation);
        playerObject.GetComponent<PlayerController>().manager = gameObject.transform.GetComponent<Manager>();
    }

    public void GameOver()
    {
        //ゲームオーバー時にタイトルを表示する。
        title.SetActive(true);
    }

    public bool IsPlaying()
    {
        //タイトルが表示中ならゲーム中ではない。非表示ならゲーム中。
        return title.activeSelf == false;
    }
}
