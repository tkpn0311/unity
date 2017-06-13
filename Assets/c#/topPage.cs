using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class topPage : MonoBehaviour {

	public Text oneMassage;
	public Text Score;

	//スタート画面で呼び出す
	void Start () {
		massage();
	}

	// Update is called once per frame
	void Update () {

	}
	public void resetButton(){
		SaveData.Clear();
	}
	//通報の回数に応じて表示するメッセージを切り替える。
	void massage () {

		if(SaveData.ContainsKey("pat_name")){

			List<string> count = SaveData.GetList<string>("pat_name",new List<string>());

			int cnt = count.Count;

			string txt = null;

			if(cnt > 0){
				txt = "巡査";
			}else if(cnt > 5){
				txt = "巡査長";
			}else if(cnt > 10){
				txt = "巡査部長";
			}
			oneMassage.text = txt;

			score(cnt);

		}
	}
	//通報回数をスコアとして表示
	void score (int cnt) {
		Score.text = "score:" + cnt.ToString();
	}
}
