using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetUp : MonoBehaviour
{
    private Canvas _canvas;

    // Use this for initialization
    void Start()
    {
        this._canvas = this.GetComponent<Canvas>();
        this._canvas.worldCamera = Camera.main;
        // キャンバスを最前面に移動
        this._canvas.planeDistance = 5.0f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
