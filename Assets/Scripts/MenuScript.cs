using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Button topOfList;
    public EventSystem eSys;

    void OnEnable()
    {
        eSys.SetSelectedGameObject(topOfList.gameObject);
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ChangeScene(string scene) {
        if (scene == "Quit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
        
    }
}
