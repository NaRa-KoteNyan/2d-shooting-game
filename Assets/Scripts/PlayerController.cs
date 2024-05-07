using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    //Spaceshipコンポーネント
    CommonSpaceship spaceship;

    // 移動スピード
    private float speed = 6;

    //PlayerBulletをプレハブ
    public GameObject bullet;
    public Manager manager;

    //Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {
        //Spaceshipコンポーネントを取得
        spaceship = GetComponent<CommonSpaceship>();

        while(true)
        {
            //弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //右・左
        float x = Input.GetAxisRaw("Horizontal");

        //上・下
        float y = Input.GetAxisRaw("Vertical");

        //移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        //移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    //ぶつかった瞬間に呼び出される
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Enemy")
        {
        //弾の削除
        Destroy(c.gameObject);

        //爆発する
        spaceship.Explosion();

        //プレイヤーを削除
        Destroy(gameObject);

        //ManagerのGameOverメソッドを呼び出す
        manager.GameOver();
        }
    }
}
