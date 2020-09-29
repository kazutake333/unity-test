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
        if (Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.M))
        {
            bean.setInputKeyDowned(true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)
            || Input.GetKeyUp(KeyCode.DownArrow)
            || Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.LeftArrow)
            || Input.GetKeyUp(KeyCode.M))
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
