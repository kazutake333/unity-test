using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalEventScript : MonoBehaviour {
    GameObject timerText;
    TimerScript timerScript;

    // Use this for initialization
    void Start () {
        timerText = GameObject.Find("TimerText");
        timerScript = timerText.GetComponent<TimerScript>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("GoalFlag"))
        //{
        //    Destroy(gameObject);
        //}
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("すり抜けた！");
        //float a = timerScript.countTime;
        //Debug.Log(a);
        // タイマー情報を次のシーンへ渡す
        SceneManager.sceneLoaded += GameSceneLoaded;
        // リザルトシーンへ遷移
        SceneManager.LoadScene("BallLdyResult_01");
    }
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("GameManager").GetComponent<ResultSetScript>();

        // データを渡す処理
        gameManager.resultTime = timerScript.countTime;

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
