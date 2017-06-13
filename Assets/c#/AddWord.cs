using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ButtonExtention))]

public class AddWord : MonoBehaviour {
	//使用するスクリプトがアタッチされているオブジェクト
	GameObject script;
	//使用するスクリプト
	searchWord t1;

	// Use this for initialization
	void Start () {
		//使用するスクリプトがアタッチされているオブジェクトを変数に格納
		script = GameObject.Find("script");
		//スクリプトを変数に格納
		t1 = script.GetComponent<searchWord>();
		//このオブジェクトにアタッチされたスクリプト
		var button = GetComponent<ButtonExtention>();
		//ボタンをクリックした際に呼び出される関数
		button.onClick.AddListener(() => addWord());
		//ボタンが長押しされた際にに呼び出される関数
		button.onLongPress.AddListener(() => Delete());
	}

	// Update is called once per frame
	void Update () {
	}

	//ボタンクリック
	public void addWord () {
		//このスクリプトがアタッチされたオブジェクトのテキスト取得
		string text = this.GetComponentInChildren<Text>().text;
		//searchWord.csから関数を呼び出し
		t1.addSearchWord(text);
	}
	//ボタン長押し
	public void Delete (){
		//このボタンが何番目のボタンか
		int num = int.Parse(this.gameObject.name);
		//searchWord.csから関数を呼び出し
		t1.delete(num);
		//このオブジェクトを削除
		Destroy(this.gameObject);
	}
}
