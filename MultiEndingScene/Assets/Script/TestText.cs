using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestText : MonoBehaviour
{
    private GameEventListener eventListener = null;
    private Text text = null;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        eventListener = GetComponent<GameEventListener>();
        eventListener.Response.AddListener(ChangeText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeText()
    {
        text.text = "死亡";
    }
}
