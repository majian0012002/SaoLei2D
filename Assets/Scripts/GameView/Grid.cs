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
	//本格是否是地雷
	bool isLei = false;
	//本格的数字
	int currentNum = 0;

	//上层格子背景
	public GameObject normal;
	//底层格子背景
	public GameObject clicked;
	//格子数字对象
	public GameObject num;
	//格子地雷对象
	public GameObject dilei;


	// Use this for initialization
	void Start () {
		normal.SetActive (true);
		clicked.SetActive (false);
		num.SetActive (false);
		dilei.SetActive (false);
		startCol = normal.GetComponent<SpriteRenderer> ().color;
		hoverCol = new Color (0.203f,0.102f,0.624f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		//mac平台
		if (Application.platform == RuntimePlatform.OSXEditor) {
			if (Input.GetMouseButtonDown (0)) {		//点击鼠标左键
				Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (new Vector2(mousePosition.x,mousePosition.y),
					Vector2.zero);
				//如果射线碰撞到了grid
				if (hit.collider != null && hit.collider.gameObject.tag.Equals ("Grid")) {
					normal.GetComponent<SpriteRenderer> ().color = startCol;
					Debug.Log ("Touch!!!!");
					normal.SetActive (false);
					clicked.SetActive (true);
					GenerateTarget ();
				}
			}
		}

	}

	//鼠标覆盖事件
	void OnMouseOver() {
		normal.GetComponent<SpriteRenderer> ().color = hoverCol;
	}

	//鼠标离焦事件
	void OnMouseExit() {
		normal.GetComponent<SpriteRenderer> ().color = startCol;
	}

	//鼠标点击后区别显示数字还是地雷
	void GenerateTarget () {
		if (isDilei ()) {
			dilei.SetActive (true);
		} else {
			getDisplaynum ();
			num.SetActive (true);
			DisplayNum dis = num.GetComponent<DisplayNum> ();
			dis.index = currentNum;
		}
	}

	//确定是否是地雷
	bool isDilei () {
		return false;
	}

	//计算应该显示的数字
	void getDisplaynum () {
		currentNum = 4;
	}
}
