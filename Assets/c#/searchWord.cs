using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class searchWord : MonoBehaviour {
	//検索フィールド
	public InputField Input;
	//ボタン配置の親となるオブジェクト
	public GameObject KEYWORD;
	public GameObject HASHTAG;
	//スクロール表示するオブジェクト
	public GameObject Scroll;
	//検索ワードのボタン
	public GameObject prefabButton;
	//ポップアップの親となるオブジェクト
	public GameObject popUp_object;
	//ポップアップのオブジェクト
	public GameObject prefabPop;

	public GameObject test;
	//表示するワードを確認
	bool keyword = true;

	List<string> wordList = new List<string>();
	List<string> hashtagList = new List<string>();

	//スタート関数
	void Start () {
		//検索ワードを共有
		searchWordSet();
		listCheack();
		//検索ワードを配置
		wordButtonSet();
		keyJudge();
	}

	// Update is called once per frame
	void Update () {

	}

	//検索フィールドを共有
	void searchWordSet (){
		Input.GetComponent<InputField>().text = dataScript.searchWord;
	}

	void listCheack(){
		if(SaveData.ContainsKey("searchWordList"))wordList = SaveData.GetList<string>("searchWordList", new List<string>());
		if(SaveData.ContainsKey("hashtagWordList"))hashtagList = SaveData.GetList<string>("hashtagWordList", new List<string>());
	}

	//すでに登録されている検索ワードを登録したボタンを作成
	public void wordButtonSet (){
		//登録されている検索ワードの数だけ繰り返し
		for(int i = 0;i<wordList.Count;i++){
			//キーワードのボタンを作成
			buttonCreate(i,true);
		}
		addButton(true);
		//登録されているハッシュタグの数だけ繰り返し
		for(int i = 0;i<hashtagList.Count;i++){
			//ハッシュタグボタンの作成
			buttonCreate(i,false);
		}
		addButton(false);
	}
	//ボタンの作成
	public void buttonCreate (int num,bool judge){
		var item = GameObject.Instantiate(prefabButton) as GameObject;
		item.name = num.ToString();

		if(judge){
			//キーワード
			item.transform.SetParent(KEYWORD.transform, false);
			item.GetComponentInChildren<Text>().text = wordList[num];
		}else{
			//ハッシュタグ
			item.transform.SetParent(HASHTAG.transform, false);
			item.GetComponentInChildren<Text>().text = hashtagList[num];
		}
	}

	//ボタンの追加をする関数
	public void addWordButton (){
		GameObject obj =　Instantiate(prefabPop) as GameObject;
		obj.transform.SetParent(popUp_object.transform,false);
		popUpScript dialog = obj.GetComponent<popUpScript>();

		dialog.SetEvent(
		()=>{
			//Yes押下時のイベント
			InputField input = obj.transform.FindChild("InputField").gameObject.GetComponent<InputField>();
			if(input.text == ""){
				Debug.Log("入力が必要です!");
			}else{
				if(keyword){
					wordList.Add(input.text);
					buttonCreate(wordList.Count-1,keyword);
					addButton(true);
					SaveData.SetList<string>("searchWordList", wordList);
				}else{
					hashtagList.Add("#" + input.text);
					buttonCreate(hashtagList.Count-1,keyword);
					addButton(false);
					SaveData.SetList<string>("hashtagWordList", hashtagList);
				}
			}
		},
		()=>{
			//No押下時のイベント
				Debug.Log("No");
		});
	}

	//ボタンを削除する関数
	public void delete (int num){
			if(keyword){
				//キーワード
				wordList.RemoveAt(num);

				for(int i = num;i<wordList.Count;i++){
					Debug.Log(i);
					GameObject button = KEYWORD.transform.Find(""+(i+1).ToString()).gameObject;

					button.name = ""+i;
				}
				addButton(true);
				SaveData.SetList<string>("searchWordList", wordList);
			}else{
				//ハッシュタグ
				hashtagList.RemoveAt(num);

				for(int i = num;i<hashtagList.Count;i++){
					Debug.Log(i);
					GameObject button = HASHTAG.transform.Find(""+(i+1).ToString()).gameObject;

					button.name = ""+i;
				}
				addButton(false);
				SaveData.SetList<string>("hashtagWordList", hashtagList);
			}

			SaveData.Save();
	}

	//検索ワードを追加
	public void addSearchWord (string text){
		//引数のテキストをインプットフィールドに格納
		if(Input.text != ""){
			Input.text += " " + text;
		}else{
			Input.text += text;
		}
		//検索ワードをまとめて入れる
		dataScript.searchWord = Input.text;
	}

	//表示するボタンを判定
	void keyJudge () {
		if(keyword){
			KEYWORD.SetActive(true);
			HASHTAG.SetActive(false);

			Scroll.GetComponent<ScrollRect>().content = KEYWORD.GetComponent<RectTransform>();
		}else{
			KEYWORD.SetActive(false);
			HASHTAG.SetActive(true);

			Scroll.GetComponent<ScrollRect>().content = HASHTAG.GetComponent<RectTransform>();
		}
	}
	//キーワードを表示
	public void keyButton (){
		keyword = true;
		keyJudge();
	}
	//ハッシュタグを表示
	public void hashButton (){
		keyword = false;
		keyJudge();
	}

	public void sceneChange (int num){
			if(num == 0){
				dataScript.searchWord = Input.GetComponent<InputField>().text;
				SaveData.Save();
				SceneManager.LoadScene ("tweetList");
			}else if(num == 1){
				SaveData.Save();
				SceneManager.LoadScene ("top");
			}
	}

	void addButton(bool x){
		if(x){
			KEYWORD.transform.Find("wordAdd").GetComponent<Transform>().SetSiblingIndex(wordList.Count+1);
		}else{
			HASHTAG.transform.Find("wordAdd").GetComponent<Transform>().SetSiblingIndex(hashtagList.Count+1);
		}
	}
}
