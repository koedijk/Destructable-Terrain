using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NewTerrain();
	}
    public void NewTerrain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
