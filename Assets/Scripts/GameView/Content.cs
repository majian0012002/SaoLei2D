using UnityEngine;
using System.Collections;

public class Content : MonoBehaviour {

	//是否是地雷
	public bool isDilei = false;
	//若不是地雷应该显示的数字
	public int num = 0;
	//精灵图集
	public Sprite[] sprites;

	//spriteRender组件
	SpriteRenderer spr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetSprite () {
		spr = GetComponent<SpriteRenderer> ();
		if (isDilei) {
			spr.sprite = sprites [10];
		} else {
			spr.sprite = sprites [num];
		}
	}
}
