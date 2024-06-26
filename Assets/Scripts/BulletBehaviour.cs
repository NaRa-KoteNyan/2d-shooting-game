using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    //弾の移動スピード
    public int speed = 10;

    //ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 5;

    //攻撃力
    public int power = 1;

    void Start()
    {
        //ローカル座標のY軸方向に移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        //lifeTime秒後に削除
        Destroy(gameObject,lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
