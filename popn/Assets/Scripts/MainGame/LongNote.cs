using System;
using UnityEngine;
using MinseoMathUtil;

public class LongNote : Note
{
    private Single _startYPos = 0;
    private Single _endYPos = 0;
    private Single t = 0;
    private Int32 _lineNum = 1;

    private Transform _pivot = null;

    private void Awake()
    {
        _pivot = transform.GetChild(0).transform;
    }

    private void Update()
    {
        if (transform.position.y < GameOptionMemorizer.OutOfScreenYPos - _pivot.localScale.y) RemovePooledObject();
        t += Time.deltaTime / GameOptionMemorizer.Instance.noteSpeed;

        //#todo : ������ �߰��Ǹ� ���� ����� ������ ������� ���� ��Ʈ�� �����̵���(������ ���ܵ� ��ũ�� �и��� �ʵ���) �ٲٱ�
        transform.position = new Vector3(
            GameOptionMemorizer.FirstLineXPosition + (GameOptionMemorizer.LineSpace * (_lineNum - 1)),
            MinseoMath.Lerp(_startYPos, _endYPos, t),
            transform.position.z);
    }
    public override void SpawnNote(int num, float timing, float otherInfo)
    {
        _startYPos = GameOptionMemorizer.StartLineYPos + (GameOptionMemorizer.Instance.UserNoteSpeed - 1.0f);
        _endYPos = GameOptionMemorizer.EndLineYPos;
        t = (GameOptionMemorizer.Instance.songTime + GameOptionMemorizer.Instance.noteSpeed) - timing; //��ġ ����
        _pivot.localScale = new Vector3(1, otherInfo, 1);
        _lineNum = num;
    }
}
