using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public GameObject gridPref;

	Vector3 startPoint;
	float width = 0;
	float height = 0;

	// Use this for initialization
	void Start () {
		startPoint = new Vector3 (Camera.main.pixelHeight,0,Camera.main.nearClipPlane);
		getWidthAndHeightOfGrid ();
		Debug.Log (width + " " + height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void getWidthAndHeightOfGrid () {
		width = gridPref.GetComponent<BoxCollider2D> ().bounds.size.x;
		height = gridPref.GetComponent<BoxCollider2D> ().bounds.size.y;
	}
}
