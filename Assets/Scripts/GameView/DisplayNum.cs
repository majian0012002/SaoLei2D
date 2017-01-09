using UnityEngine;
using System.Collections;

public class DisplayNum : MonoBehaviour {

	//数字的图片集合
	public Sprite[] sprites;
	//Sprite组件
	SpriteRenderer spr;

	//sprite的索引
	public int index=0;

	// Use this for initialization
	void Start () {
		spr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		spr.sprite = sprites[index];
	}
}
