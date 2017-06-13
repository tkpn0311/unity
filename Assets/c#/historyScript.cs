using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//活動記録を確認するためのオブジェクト
public class historyScript : MonoBehaviour {

	public Text patCnt;

	public Text LastTime;

	List<string> name = new List<string>();
	List<string> id = new List<string>();
	List<string> time = new List<string>();


	// Use this for initialization
	void Start () {
		if(SaveData.ContainsKey("pat_name") && SaveData.ContainsKey("pat_id") && SaveData.ContainsKey("pat_time")){
			name = SaveData.GetList<string>("pat_name",new List<string>());
			id = SaveData.GetList<string>("pat_id",new List<string>());
			time = SaveData.GetList<string>("pat_time",new List<string>());

			patCount();
			lastTime();
		}
	}

	// Update is called once per frame
	void Update () {

	}
	//通報回数
	void patCount (){
		patCnt.text = "報告件数:"+ (name.Count).ToString() + "件";
	}
	//最終活動日時
	void lastTime (){
		LastTime.text = time[time.Count-1];
	}
}
