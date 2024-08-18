using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinseoMathUtil;

public class LongNote : Note
{
    private Single _startYPos = 0;
    private Single _endYPos = 0;
    private Single t = 0;

    private Transform _pivot = null;

    private void Awake()
    {
        _pivot = transform.GetChild(0).transform;
    }

    private void Update()
    {
        if (transform.position.y < GameOptionMemorizer.OutOfScreenYPos) RemovePooledObject();
        t += Time.deltaTime / GameOptionMemorizer.Instance.noteSpeed;

        //#todo : ������ �߰��Ǹ� ���� ����� ������ ������� ���� ��Ʈ�� �����̵���(������ ���ܵ� ��ũ�� �и��� �ʵ���) �ٲٱ�
        transform.position = new Vector3(
            transform.position.x,
            MinseoMath.Lerp(_startYPos, _endYPos, t),
            transform.position.z);
    }
    public override void SpawnNote(int num, float timing, float otherInfo)
    {
        _startYPos = GameOptionMemorizer.StartLineYPos + (GameOptionMemorizer.Instance.UserNoteSpeed - 1.0f);
        _endYPos = GameOptionMemorizer.EndLineYPos;
        t = timing - (GameOptionMemorizer.Instance.songTime + GameOptionMemorizer.Instance.noteSpeed); //��ġ ����
        _pivot.localScale = new Vector3(1, otherInfo, 1);
    }
}
