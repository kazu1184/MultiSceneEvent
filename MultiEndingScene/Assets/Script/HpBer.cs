using UnityEngine;
using UnityEngine.UI;

public class HpBer : MonoBehaviour
{
    [SerializeField, Header("プレイヤーステータス")]
    private StatusParam playerStatus = null;

    private Slider slider = null;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
        playerStatus.hp.mChanged += (data) =>
        {
            slider.value = (float)data / (float)playerStatus.initialHp;
        };
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DestroyOwn()
    {
        Destroy(this.gameObject);
    }
}
