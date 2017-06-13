using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using twitter;

//シーン読み込み用のスクリプト
public class buttonClick : MonoBehaviour
{
	//public GetTweet script;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void loadTop ()
	{
		SceneManager.LoadScene ("top");
	}

	public void loadTweetList ()
	{
		SceneManager.LoadScene ("tweetList");
	}

	public void loadProfile ()
	{
		SceneManager.LoadScene ("profile_scene");
	}

	public void loadHistory ()
	{
		SceneManager.LoadScene ("history");
	}

	public void loadWordSearch ()
	{
		SceneManager.LoadScene ("wordSearch");
	}

	public void addWord ()
	{
		SceneManager.LoadScene ("addWord");
	}

	public void pat_comp ()
	{
		SceneManager.LoadScene ("webSample");
	}

	public void pat_data ()
	{
		SceneManager.LoadScene ("pat_data");
	}

	public void pat_kakunin (bool cheak)
	{
		if(cheak){
			GameObject.Find("script").GetComponent<GetTweet>().getTweet(int.Parse(this.name));
		}
		SceneManager.LoadScene ("pat_kakunin");
	}

	public void searchHistory ()
	{
		SceneManager.LoadScene ("searchHistory");
	}

	public void wordDelete ()
	{
		SceneManager.LoadScene ("wordDelete");
	}

	public void backBotton (){

		int cnt = dataScript.sceneMove.Count;

		string scene = dataScript.sceneMove[cnt];

		dataScript.sceneMove.RemoveAt(cnt);

		SceneManager.LoadScene(scene);
	}
}
