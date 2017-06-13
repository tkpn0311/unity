using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//unity上でwebサイトを表示するサンプル
public class WebviewSample : MonoBehaviour {

  private string url = "https://support.twitter.com/forms/cse";
  WebViewObject webViewObject;

  List<string> name = new List<string>();

  List<string> id = new List<string>();

  List<string> time = new List<string>();

  public GameObject prefabPop;

  public GameObject popUpParent;

  // Use this for initialization
  void Start () {
    if(SaveData.ContainsKey("pat_name") && SaveData.ContainsKey("pat_id") && SaveData.ContainsKey("pat_time")){
      name = SaveData.GetList<string>("pat_name", new List<string>());
      id = SaveData.GetList<string>("pat_id", new List<string>());
      time = SaveData.GetList<string>("pat_time", new List<string>());
    }
    webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
    webViewObject.Init((msg) => {
        Debug.Log(msg);
    });
    webViewObject.LoadURL(url);
    webViewObject.SetMargins(0, 0, 0, Screen.height/4 * 1);
    webViewObject.SetVisibility(true);
  }

  void Update (){

  }

  public void link (){
    UniClipboard.SetText (dataScript.tweet_link);
  }

  public void tenpre (){
    UniClipboard.SetText (dataScript.tweet_text);
  }

  public void mail (){
    UniClipboard.SetText (SaveData.GetString("userAdress"));
  }

  public void back (){
    webViewObject.SetVisibility(false);
    GameObject obj =　Instantiate(prefabPop) as GameObject;
		obj.transform.SetParent(popUpParent.transform,false);
		popUpScript dialog = obj.GetComponent<popUpScript>();

		dialog.SetEvent(
		()=>{
			//Yes押下時のイベント
      name.Add(dataScript.tweet_name);
      id.Add(dataScript.tweet_id);
      time.Add(System.DateTime.Now.ToString());
      SaveData.SetList<string>("pat_name",name);
      SaveData.SetList<string>("pat_id",id);
      SaveData.SetList<string>("pat_time",time);

      SaveData.Save();
      SceneManager.LoadScene ("tweetList");
		},
		()=>{
			//No押下時のイベント
				Debug.Log("No");
        SceneManager.LoadScene ("tweetList");
		});
  }
}
