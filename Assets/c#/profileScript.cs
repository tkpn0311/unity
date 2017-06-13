using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class profileScript : MonoBehaviour {

	//プロファイルの名前
	public InputField name;
	//プロファイルの学校名
	public InputField school;
	//プロファイルのメールアドレス
	public InputField adress;
	string Name = null;
	string School = null;
	string Adress = null;

	//プロファイルの入力をさせるスクリプト
	void Start () {
		if(SaveData.ContainsKey("userName")){
			Name = SaveData.GetString("userName");
			name.GetComponent<InputField>().text = Name;
		}
		if(SaveData.ContainsKey("userSchool")){
			School = SaveData.GetString("userSchool");
			school.GetComponent<InputField>().text = School;
		}
		if(SaveData.ContainsKey("userAdress")){
			Adress = SaveData.GetString("userAdress");
			adress.GetComponent<InputField>().text = Adress;
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void enterButton (){
		string nameT = name.GetComponent<InputField>().text;
		string schoolT = school.GetComponent<InputField>().text;
		string adressT = adress.GetComponent<InputField>().text;
		if(Name != nameT)SaveData.SetString("userName", nameT);
		if(School != schoolT)SaveData.SetString("userSchool", schoolT);
		if(Adress != adressT)SaveData.SetString("userAdress", adressT);
		SaveData.Save();
	}
}
