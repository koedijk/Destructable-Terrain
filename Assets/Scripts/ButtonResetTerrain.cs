using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonResetTerrain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetTerrain()
    {
        SceneManager.LoadScene("ReloadScreen");
    }
}
