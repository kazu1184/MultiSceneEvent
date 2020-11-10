# ScriptableObjectでEventを管理する

## ScriptableObjectとは

1. スクリプトインスタンスから独立している
2. 大量の共有データを保存できる
3. データが一つなので、メモリの節約につながる
4. エディター上から数値を変更できる

![エディター](https://github.com/kazu1184/MultiSceneEnding/blob/images/images/ScriptableObject.PNG?raw=true "プレイヤーステータス")

今回はこの**ScriptableObject**をデータとして扱うのではなく、1のスクリプトインスタンスから
独立しているという点を利用したEvent管理についてまとめていく

## Eventとは

ここで明記しているEventとは**UnityEngine.Events**のことである登録した関数を指定のタイミングで
呼んでくれる機能である。プレイヤー死亡時にアニメーションやエフェクト・敵の挙動
ステートマシーンへのシーン遷移など複数のクラスに影響を与える時などすごく便利である。

####　イベント通知側

```c#
using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    public UnityEvent unityEvent;

    private void Start()
    {
        // イベントの通知を飛ばす
        unityEvent.Invoke();
    }
}
```

#### イベント購読側

```c#
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    public GameEvent event;

    private void Awaik()
    {
        // イベント発生時呼ばれる関数の登録
        event.unityEvent.AddListener(() => Debug.Log("ゲームスタート"));
    }
}
```

この記述だけで特定のタイミングで特定の関数を実行することができる。これは、アップデートで
タイミングを見続けるより無駄がなく、ほかのオブジェクトの参照が少なくなり管理もより楽にできる

## なぜイベントとScriptableObjectなのか

ここまで見るとなぜイベントとScriptableObjectを活用しなければならないのか謎に思った方
もいると思う。この最大の要因はデフォルトのイベントはシーンが同じ所にあることしか
想定できないことが問題だ。一人での制作ならばそれだけで問題はないと思うが、
大規模になるにつれて複数のシーンでの作業を採用した場合エディター上でアタッチができずに
スクリプトから設定したりシングルトンパターンのマネージャーが必要となってしまう。

####　マルチシーンを使用した場合のデフォルトイベントの動き

![エディター](https://github.com/kazu1184/MultiSceneEnding/blob/images/images/DefalutEvent.gif?raw=true "デフォルトイベント")

このように、マルチシーンを使用すると別シーンのオブジェクトがアタッチできない。
せっかくのイベントの良さが使いきれない。

## ScriptableObjectを使ったイベント

今回の本題。ScriptableObjectを使用したイベント管理システムだ。
このシステムは2つのクラスがいる。

1. ScriptableObjectを継承したGameEventクラス
2. MonoBehaviourを継承したGameEventListenerクラス

####　**[コード例]** GameEvent ScriptableObject

```c#
[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
            listeners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListener listener)
    {  
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
```

####　**[コード例]** GameEventListener

```c#
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;

    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
```

####　イベントの流れ

1. **GameEvent** から **Raise()** が呼ばれる
2. **GameEventListenerのリスト** へ **OnEventRaised()** 呼ばれる
3. イベントの発行

## エディター上での動き
