using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ポップアップを表示するスクリプト
public class popUpScript : MonoBehaviour {
	private System.Action positiveRes;
	private System.Action negativeRes;
	public void SetEvent(System.Action pos, System.Action neg){
		positiveRes = pos;
		negativeRes = neg;
	}

	//インスペクタ上でボタンと紐づけ
	public void OnClickPositive(){
		if(positiveRes != null){
			positiveRes();
		}
		Destroy(this.gameObject);
	}
	//インスペクタ上でボタンと紐づけ
	public void OnClickNegative(){
		if(negativeRes != null){
			negativeRes();
		}
		Destroy(this.gameObject);
	}
}
