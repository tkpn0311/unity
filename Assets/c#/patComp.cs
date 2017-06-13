using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patComp : MonoBehaviour {

	//通報完了画面
	void Start () {

		int count = SaveData.GetInt("patCount");

		count++;

		string lastTime = System.DateTime.Now.ToString();

		SaveData.SetInt("patCount", count);
		SaveData.SetString("lastTime", lastTime);
    SaveData.Save ();

	}

	// Update is called once per frame
	void Update () {

	}
}
