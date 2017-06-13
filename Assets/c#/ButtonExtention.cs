using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

//ボタンの長押しをできるようにするスクリプト
public class ButtonExtention : Button
{
    //新しいEventとして宣言
    public UnityEvent onLongPress = new UnityEvent();
    //長押し判定時間
    public float longPressIntervalSeconds = 1.0f;
    //押している時間
    private float pressingSeconds    = 0.0f;
    //長押しされたかどうか
    private bool isEnabledLongPress  = true;
    //タップされたかどうか
    private bool isPressing          = false;

    void Update()
    {
        //どちらもtrueだった場合
        if (isPressing && isEnabledLongPress)
        {
            //押している時間を計測
            pressingSeconds += Time.deltaTime;
            //押した時間が判定の時間を超えた場合
            if (pressingSeconds >= longPressIntervalSeconds)
            {
                //長押しした時に実行したい関数を呼び出し
                onLongPress.Invoke();
                //長押し判定をオフ
                isEnabledLongPress = false;
            }
        }
    }
    
    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        isPressing = true;
    }

    public override void OnPointerUp (UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        pressingSeconds = 0.0f;
        isEnabledLongPress = true;
        isPressing = false;
    }
}
