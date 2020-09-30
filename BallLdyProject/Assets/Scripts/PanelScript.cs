using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {
    /// <summary>
    /// ManipulationCanvasオブジェクト
    /// </summary>
    [SerializeField] private CanvasGroup OBJECT_MANIPULATION_CANVAS;

    ManipulationCanvasBean bean;

    // Use this for initialization
    void Start () {
        this.bean = new ManipulationCanvasBean();
        bean.setInputKeyDowned(false);
        bean.setClearLevel(1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        Hashtable ht = new Hashtable();
        ht["KEY_DOWNED_UP"] = (bool)false;
        ht["KEY_DOWNED_DOWN"] = (bool)false;
        ht["KEY_DOWNED_RIGHT"] = (bool)false;
        ht["KEY_DOWNED_LEFT"] = (bool)false;
        ht["KEY_DOWNED_M"] = (bool)false;

        // 押下キー情報をHashtableへ一時格納
        if (Input.GetKey(KeyCode.UpArrow)) ht["KEY_DOWNED_UP"] = (bool)true;
        if (Input.GetKey(KeyCode.DownArrow)) ht["KEY_DOWNED_DOWN"] = (bool)true;
        if (Input.GetKey(KeyCode.RightArrow)) ht["KEY_DOWNED_RIGHT"] = (bool)true;
        if (Input.GetKey(KeyCode.LeftArrow)) ht["KEY_DOWNED_LEFT"] = (bool)true;
        if (Input.GetKey(KeyCode.M)) ht["KEY_DOWNED_M"] = (bool)true;

        if ((bool)ht["KEY_DOWNED_UP"]
            || (bool)ht["KEY_DOWNED_DOWN"]
            || (bool)ht["KEY_DOWNED_RIGHT"]
            || (bool)ht["KEY_DOWNED_LEFT"]
            || (bool)ht["KEY_DOWNED_M"])
        {
            bean.setInputKeyDowned(true);
        }

        if (!(bool)ht["KEY_DOWNED_UP"]
            && !(bool)ht["KEY_DOWNED_DOWN"]
            && !(bool)ht["KEY_DOWNED_RIGHT"]
            && !(bool)ht["KEY_DOWNED_LEFT"]
            && !(bool)ht["KEY_DOWNED_M"])
        {
            bean.setInputKeyDowned(false);
        }

        FadeSwitch(bean);
    }

    /// <summary>
    /// 操作キーが入力されている間は操作マニュアルを表示させない
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="value"></param>
    private void FadeSwitch(ManipulationCanvasBean bean)
    {
        // キーが押されている間
        if (bean.isInputKeyDowned())
        {
            FadeActionFatdeOut(bean);
        }
        // 押されたキーが離される
        else
        {
            FadeActionFatdeIn(bean);
        }
    }

    /// <summary>
    /// フェードアウト実行
    /// </summary>
    /// <param name="value">透明度[0f~1.0f]</param>
    private void FadeActionFatdeOut(ManipulationCanvasBean bean)
    {
        float value = bean.getClearLevel();
        if (0f <= value)
        {
            value -= 0.1f;
        }
        else
        {
            value = 0f;
        }
        bean.setClearLevel(value);
        OBJECT_MANIPULATION_CANVAS.alpha = bean.getClearLevel();
    }

    /// <summary>
    /// フェードイン実行
    /// </summary>
    /// <param name="value">透明度[0f~1.0f]</param>
    private void FadeActionFatdeIn(ManipulationCanvasBean bean)
    {
        float value = bean.getClearLevel();
        if (value <= 1.0f)
        {
            value += 0.1f;
        }
        else
        {
            value = 1.0f;
        }
        bean.setClearLevel(value);
        OBJECT_MANIPULATION_CANVAS.alpha = bean.getClearLevel();
    }
}
