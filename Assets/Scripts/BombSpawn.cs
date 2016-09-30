using UnityEngine;
using System.Collections;

public class BombSpawn : MonoBehaviour {

    private Vector3 objectPos;
    [SerializeField]
    private GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 1f;       // we want 2m away from the camera position
            objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(bulletPrefab, objectPos, Quaternion.identity);
        }
    }
}
