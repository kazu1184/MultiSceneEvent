using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーステータス")]
    private StatusParam playerStatus = null;
    [SerializeField, Header("プレイヤー死亡イベント")]
    private GameEvent gameEvent = null;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus.hp.mChanged += (data) =>
        {
            if (data <= 0)
                gameEvent.Raise();
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            playerStatus.hp.Value -= 10;

        if (Input.GetKeyDown(KeyCode.E))
            playerStatus.hp.Value += 10;

    }
}
