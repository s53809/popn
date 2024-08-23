using System;
using UnityEngine;
using MinseoMathUtil;

public class PopNote : Note
{
    private Single _startYPos = 0;
    private Single _endYPos = 0;
    private Single t = 0;
    private Int32 _lineNum = 1;
    protected override void Update()
    {
        base.Update();
        if (transform.position.y < GameOptionMemorizer.OutOfScreenYPos) RemovePooledObject();
        t += Time.deltaTime / GameOptionMemorizer.Instance.noteSpeed;
        
        //#todo : ������ �߰��Ǹ� ���� ����� ������ ������� ���� ��Ʈ�� �����̵���(������ ���ܵ� ��ũ�� �и��� �ʵ���) �ٲٱ�
        transform.position = new Vector3(
            GameOptionMemorizer.FirstLineXPosition + (GameOptionMemorizer.LineSpace * (_lineNum - 1)),
            MinseoMath.Lerp(_startYPos, _endYPos, t), 
            transform.position.z);
    }
    public override void SpawnNote(int num, float timing, float otherInfo)
    {
        base.SpawnNote(num, timing, otherInfo);
        _startYPos = GameOptionMemorizer.StartLineYPos + (GameOptionMemorizer.Instance.UserNoteSpeed - 1.0f);
        _endYPos = GameOptionMemorizer.EndLineYPos;
        t = (GameOptionMemorizer.Instance.songTime + GameOptionMemorizer.Instance.noteSpeed) - timing; //��ġ ����
        _lineNum = num;
    }
}