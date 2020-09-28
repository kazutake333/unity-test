using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        float a = timerScript.countTime;
        Debug.Log(a);
        // タイマー情報を次のシーンへ渡す
        // リザルトシーンへ遷移
    }
}
