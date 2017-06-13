using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataScript : MonoBehaviour
{
	// Use this for initialization
	//ツイート内容やIDを保存するlist
	//public static List<string> tweet_cont =  new List<string>();
	//public static List<string> tweet_id =  new List<string>();
	//public static List<string> tweet_name =  new List<string>();

	//選択されたツイートの情報
	public static string tweet_text;
	public static string tweet_id;
	public static string tweet_name;
	public static string tweet_link;
	//検索ワード
	public static string searchWord = "";

	public static List<string> sceneMove = new List<string>();

	/*//通報者のプロフ
	public static string name;
	public static string schoolName;
	public static string adress;

	//通報回数カウント
	public static int patCount;
	//最終活動時間
	public static string lastTime;

	//登録された検索ワードを保存するlist
	public static List<string> searchWordList = new List<string>();

	public static List<string> searchHashtagList = new List<string>();
	*/
}
