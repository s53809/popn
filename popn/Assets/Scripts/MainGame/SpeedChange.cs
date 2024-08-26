using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChange : Note
{
    private Single _speedValue = 0;
    private Single _timing = 0;
    public override void SpawnNote(int num, float timing, float otherInfo)
    {
        base.SpawnNote(num, timing, otherInfo);
        _speedValue = otherInfo;
        _timing = timing;

    }

    protected override void Update()
    {
        base.Update();
        if(_timing <= GameOptionMemorizer.Instance.songTime)
        {
            GameOptionMemorizer.Instance.noteSpeed = 1 / _speedValue;
            RemovePooledObject();
        }
    }
}
