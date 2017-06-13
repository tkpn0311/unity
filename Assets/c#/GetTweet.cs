using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using twitter;

public class GetTweet : MonoBehaviour {
	//検索フィールド
	public InputField input;
	//ツイートの取得件数
	int COUNT = 30;
	//ツイートボタンを配置する親オブジェクト
	public GameObject scroll_content = null;
	//配置するツイートボタンのprefab
	public GameObject tweetButton;

	public GameObject parent;

	public GameObject prefabPop;


	List<string> tweet_cont =  new List<string>();
	List<string> tweet_id =  new List<string>();
	List<string> tweet_name =  new List<string>();

	//検索した結果をjson形式で保存しておくスクリプト
	SearchTweetsResponse Response;

	// Use this for initialization
	void Start ()
	{
		//APIキーなどの初期設定
		twitterSetting();
		//検索ワードを共有
		searchWordSet();
		//キーワードでツイートの検索
		tweetSearch(dataScript.searchWord);
	}

	// Update is called once per frame
	void Update ()
	{

	}

	//APIの初期設定
	void twitterSetting () {
		twitter.Client.consumerKey       = "hAcq6sLxEt2S8gXryEgi0cXMo";
    twitter.Client.consumerSecret    = "q6Q1JDkVkaHMFp61HBuvmPmwL9JnXbF32NDBWu7dNXganKbfMI";
    twitter.Client.accessToken       = "410076678-xxeFVK3r0BJEqNa1tHFxQMfVl8aZNddmDvboAHjP";
    twitter.Client.accessTokenSecret = "i4E14S9Ehk0tabtuwUD2FnvXXaaxjkB3celXv0UxgfcKD";
	}

	//検索ワードを共有
	void searchWordSet(){
		input.text = dataScript.searchWord;
	}
	//検索フィールド
	public void searchField () {
		string text = input.text;

		dataScript.searchWord = text;

		tweetSearch(text);
	}

	//キーワードでツイートの検索
	public void tweetSearch(string keyword) {
		if(!(keyword == "")){
			Dictionary<string, string> parameters = new Dictionary<string, string>();
	  	parameters ["q"] = keyword;       // 検索ワード
	  	parameters ["count"] = COUNT.ToString();   // 取得するツイート数
	  	StartCoroutine (twitter.Client.Get ("search/tweets", parameters, new twitter.TwitterCallback (this.Callback)));
		}else{
			reset();
		}
	}

	//tweetSearchから呼ばれるコールバック関数
	void Callback(bool success, string response) {
  	if (success) {
    	Response = JsonUtility.FromJson<SearchTweetsResponse> (response);
			tweetCreate();
  	} else {
    	Debug.Log (response);
  	}
	}
	//取得したツイートをリストに格納
	void tweetCreate(){
		if(Response.statuses.Length != 0){
			reset();
			//リストに格納したツイートをボタンオブジェクトとして配置
			tweetList();
		}else{
			Debug.Log("検索エラー");
		}
	}

	//検索したツイートの内容をボタンのテキストに表示
	void tweetList ()
	{
		//リストの長さ分ボタンを作成
		for(int i = 0;i<Response.statuses.Length;i++){
			tweetButtonCreate(i);
		}
	}
	//リストの中身をボタンオブジェクトに入れてボタン作成
	void tweetButtonCreate (int num){

		var item = GameObject.Instantiate(tweetButton) as GameObject;
		item.transform.SetParent(scroll_content.transform, false);

		item.name = num.ToString();

		item.GetComponentInChildren<Text>().text = RemoveNewLine(Response.statuses[num].text);
	}

	void　DestroyChildObject ()
	{
		//ツイートボタンを全て削除
		Transform parent_trans = scroll_content.transform;
		for(int i=0; i < parent_trans.childCount; ++i){
			GameObject.Destroy( parent_trans.GetChild( i ).gameObject );
		}
	}

	//文字列の中にある改行を消す関数
	//ツイートの内容を取得した際に改行が多く表示しきれないため
	string RemoveNewLine(string self)
	{
		return self.Replace( "\r", "" ).Replace( "\n", "" );
	}

	//初期化(オブジェクトやリストの中身)
	void reset (){
		DestroyChildObject();
		//dataScript.tweet_cont.Clear();
		//dataScript.tweet_id.Clear();
		//dataScript.tweet_name.Clear();
	}

	public void getTweet (int select){
		dataScript.tweet_text = RemoveNewLine(Response.statuses[select].text);
		dataScript.tweet_id = Response.statuses[select].user.screen_name;
		dataScript.tweet_name = Response.statuses[select].user.name;
		dataScript.tweet_link = "https://twitter.com/" + Response.statuses[select].user.screen_name + "/status/"
		+ Response.statuses[select].id_str;
	}

	//
	public void tweetInfoPop (int num){
		GameObject obj =　Instantiate(prefabPop) as GameObject;
		obj.transform.SetParent(parent.transform,false);
		popUpScript dialog = obj.GetComponent<popUpScript>();

		GameObject.Find("tweetText").GetComponent<Text>().text = Response.statuses[num].text;
		obj.transform.FindChild("screenName").GetComponent<Text>().text = Response.statuses[num].user.name;
		obj.transform.FindChild("userId").GetComponent<Text>().text = Response.statuses[num].user.screen_name;

		dialog.SetEvent(
		()=>{
			//Yes押下時のイベント
			getTweet(num);

			SceneManager.LoadScene ("pat_data");

		},
		()=>{
			//No押下時のイベント
				Debug.Log("No");
		});
	}
}
