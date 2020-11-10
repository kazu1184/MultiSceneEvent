using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameEventListener eventListener = null;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.Instance.Hover("UiScene");
        SceneManager.Instance.Hover("FieldScene");
        eventListener = GetComponent<GameEventListener>();
        eventListener.Response.AddListener(()=>SceneManager.Instance.Dispose("FieldScene"));
    }

    // Update is called once per frame
    void Update()
    {
    }

}
