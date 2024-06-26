using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    // Start is called before the first frame update

    //Waveのプレハブを格納する
    public GameObject[] waves;

    //現在のWave
    public int currentWave;

    //Managerコンポーネント
    private Manager manager;

    IEnumerator Start()
    {
        //Waveが存在しなければコルーチンを終了する
        if(waves.Length == 0)
        {
            yield break;
        }

        //Managerコンポーネントをシーン内から探して取得する
        manager = FindObjectOfType<Manager>();

        while(true)
        {
            //タイトル表示中は待機
            while(manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }


           //Waveを作成する
           GameObject wave = (GameObject)Instantiate(waves[currentWave],transform.position, Quaternion.identity);

           //WaveをEmitterの子要素にする
           wave.transform.parent = transform;

           //Waveの子要素のEnemyがすべて削除されるまで待機する
           while(wave.transform.childCount != 0)
           {
            yield return new WaitForEndOfFrame();
           } 

           //Waveの削除
           Destroy(wave);

           //格納されているWaveをすべて実行したらcurrentWaveを0にする。(最初から　-> ループ)
           if(waves.Length <= ++currentWave)
           {
            currentWave = 0;
           }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
