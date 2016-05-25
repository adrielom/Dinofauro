using UnityEngine;
using System.Collections;
using System;

public class Button : MonoBehaviour {

    public Sprite hoverSprite;
    public Sprite normalSprite;


    public delegate void OnClick(object sender, EventArgs e);

    public event OnClick Click;

    private SpriteRenderer _spriteRenderer;



	// Use this for initialization
	void Start () {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	
	}

    void OnMouseEnter()
    {
        _spriteRenderer.sprite = hoverSprite;
    }

    void OnMouseExit()
    {
        _spriteRenderer.sprite = normalSprite; 
    }

    void OnMouseDown()
    {
        if (Click != null)
        {
            Click(gameObject, new EventArgs());
        }
    }

}
