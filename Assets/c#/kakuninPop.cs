using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using twitter;

public class kakuninPop : MonoBehaviour {

	GetTweet script;

	// Use this for initialization
	void Start ()
	{
		script = GameObject.Find("script").GetComponent<GetTweet>();
		//script.getTweet(int.Parse(this.name));
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void Button (){
		script.tweetInfoPop(int.Parse(this.name));
	}

}
