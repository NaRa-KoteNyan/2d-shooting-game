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

    public GameObject gameOver;

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
        gameOver.SetActive(true);

        GameObject[] enemyobject = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject obj in enemyobject)
        {
            Destroy(obj);
        }
        GameObject[] enemybulletobject = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach(GameObject obj in enemybulletobject)
        {
            Destroy(obj);
        }
        GameObject[] playerbulletobject = GameObject.FindGameObjectsWithTag("PlayerBullet");
        foreach(GameObject obj in playerbulletobject)
        {
            Destroy(obj);
        }
    }

    public bool IsPlaying()
    {
        //タイトルが表示中ならゲーム中ではない。非表示ならゲーム中。
        return title.activeSelf == false && gameOver.activeSelf == false;
    }
}
