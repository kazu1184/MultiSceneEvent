using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptabaleObject/Param/Status")]
public class StatusParam : ScriptableObject,ISerializationCallbackReceiver
{
    public int initialHp;
    public int initialAtk;
    public int initialDef;

    // シリアライズ化させない
    [NonSerialized]
    public Selectable<int> hp = new Selectable<int>();
    [NonSerialized]
    public Selectable<int> atk = new Selectable<int>();
    [NonSerialized]
    public Selectable<int> def = new Selectable<int>();

    public void OnAfterDeserialize()
    {
        hp.Value = initialHp;
        atk.Value = initialAtk;
        def.Value = initialDef;
    }

    public void OnBeforeSerialize()
    { 
    }
}


