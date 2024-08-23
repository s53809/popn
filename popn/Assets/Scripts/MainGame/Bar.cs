using System;
using UnityEngine;
using MinseoMathUtil;

public class Bar : Note
{
    private Single _startYPos = 0;
    private Single _endYPos = 0;
    private Single t = 0;
    protected override void Update()
    {
        base.Update();
        if (transform.position.y < GameOptionMemorizer.EndLineYPos) RemovePooledObject();
        t += Time.deltaTime / GameOptionMemorizer.Instance.noteSpeed;

        //#todo : 음악이 추가되면 현재 재생된 음악의 진행률에 따라 노트가 움직이도록(음악이 끊겨도 싱크가 밀리지 않도록) 바꾸기
        transform.position = new Vector3(
            0,
            MinseoMath.Lerp(_startYPos, _endYPos, t),
            transform.position.z);
    }
    public override void SpawnNote(int num, float timing, float otherInfo)
    {
        base.SpawnNote(num, timing, otherInfo);
        _startYPos = GameOptionMemorizer.StartLineYPos + (GameOptionMemorizer.Instance.UserNoteSpeed - 1.0f);
        _endYPos = GameOptionMemorizer.EndLineYPos;
        t = (GameOptionMemorizer.Instance.songTime + GameOptionMemorizer.Instance.noteSpeed) - timing; //위치 보정
    }
}
