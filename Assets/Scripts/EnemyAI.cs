using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Spaceshipコンポーネント
    CommonSpaceship spaceship;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Spaceshipコンポーネントを取得
        spaceship = GetComponent<CommonSpaceship>();
        //ローカル座標のY軸のマイナス方向に移動する
        spaceship.Move(transform.up * -1);

        while(true)
        {
            //子要素を全て取得する
            for(int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                //ShotPositionの位置/角度で弾を撃つ
                spaceship.Shot(shotPosition);
            }

            //shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
