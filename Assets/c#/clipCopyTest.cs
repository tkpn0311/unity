using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clipCopyTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void copy (){
		UniClipboard.SetText ("text you want to clip");

		Debug.Log(UniClipboard.GetText ());
	}
}
