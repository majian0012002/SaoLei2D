using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	//格子在所有格子的行数
	int x = 0;
	//格子在所有格子的列数
	int y = 0;
	//开始的颜色
	Color startCol;
	//鼠标覆盖后的颜色
	Color hoverCol;
	//鼠标点击后的颜色
	Color clickCol;
	//本格是否是地雷
	bool isLei = false;
	//本格的数字
	int currentNum = 0;
	//SpriteRender组件
	SpriteRenderer spr;

	//上层格子
	public Sprite foreground;
	//内容物体
	public GameObject content;

	// Use this for initialization
	void Start () {
		startCol = new Color (0.203f,0.102f,0.624f,1f);
		hoverCol = new Color (0.424f,0.318f,0.859f,1f);
		clickCol = new Color (1f,1f,1f,1f);
		spr = this.GetComponent<SpriteRenderer> ();
		spr.sprite = foreground;
		spr.color = startCol;
	}
	
	// Update is called once per frame
	void Update () {
		//mac平台
		/**
		if (Application.platform == RuntimePlatform.OSXEditor) {
			if (Input.GetMouseButtonDown (0)) {		//点击鼠标左键
				Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Collider2D col = Physics2D.OverlapPoint (mousePosition,(1 << LayerMask.NameToLayer("Grid")));
				//如果射线碰撞到了grid
				if (col != null && col.gameObject.tag.Equals ("Grid")) {
					normal.GetComponent<SpriteRenderer> ().color = startCol;
					Debug.Log ("Touch!!!!");
					normal.SetActive (false);
					clicked.SetActive (true);
					GenerateTarget ();
				}
			}
		}
		**/

	}

	//鼠标覆盖事件
	void OnMouseOver() {
		spr.color = hoverCol;
	}

	//鼠标离焦事件
	void OnMouseExit() {
		spr.color = startCol;
	}

	//鼠标点击事件
	void OnMouseDown() {
		GenerateTarget ();
		spr.color = clickCol;
	}

	//鼠标点击后区别显示数字还是地雷
	void GenerateTarget () {
		if (isDilei ()) {
			content.SetActive (true);
			content.GetComponent<Content> ().isDilei = true;
			content.GetComponent<Content> ().SetSprite ();
			this.gameObject.SetActive (false);
		} else {
			getDisplaynum ();
			content.SetActive (true);
			content.GetComponent<Content> ().num = currentNum;
			content.GetComponent<Content> ().SetSprite ();
			this.gameObject.SetActive (false);
		}
	}

	//确定是否是地雷
	bool isDilei () {
		return true;
	}

	//计算应该显示的数字
	void getDisplaynum () {
		currentNum = 4;
	}
}
