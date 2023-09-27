using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRanger : BaseTowerData
{
    public float attRangeMultiple { get; set; }

    public void GreenSetData(string _name, float _att, float _attDelay, float _hp, float _attRangeMultiple)
    {
        base.SetData(_name, _att, _attDelay, _hp);
        attRangeMultiple = _attRangeMultiple;
    }
}
