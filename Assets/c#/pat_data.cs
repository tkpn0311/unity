using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using twitter;

public class pat_data : MonoBehaviour {

	public Text tweet_data;

	public Text tweet;

	public Text prof;

	public GameObject prefabPop;

	public GameObject canvas;

	string name = null;
	string school = null;
	string adress = null;

	int num = 0;
	//通報するユーザーの情報を表示するスクリプト
	void Start ()
	{
		tweet_data.text = "ID:" + dataScript.tweet_id + "\n";
		tweet_data.text = tweet_data.text + "name:" + dataScript.tweet_name + "\n";
		tweet.text = dataScript.tweet_text;

		if(SaveData.ContainsKey("userName") && SaveData.ContainsKey("userSchool") && SaveData.ContainsKey("userAdress")){
			name = SaveData.GetString("userName");
			school = SaveData.GetString("userSchool");
			adress = SaveData.GetString("userAdress");
		}

		Debug.Log(name);

		prof.text += name;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	//プロフィールが入力されていない場合
	//ポップアップを表示して入力を促す
	public void buttonClick () {
		if(name == null || school == null || adress == null){
			GameObject obj =　Instantiate(prefabPop) as GameObject;
			obj.transform.SetParent(canvas.transform,false);
			popUpScript dialog = obj.GetComponent<popUpScript>();

			dialog.SetEvent(
			()=>{
				//Yes押下時のイベント
				SceneManager.LoadScene ("profile_scene");
			},
			()=>{
			});
		}else{
			SceneManager.LoadScene ("webSample");
		}
	}
}
