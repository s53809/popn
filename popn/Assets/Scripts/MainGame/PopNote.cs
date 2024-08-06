using System;
using UnityEngine;

public class PopNote : Note
{
    private Single _startYPos = 0;
    private Single _endYPos = 0;
    private Single t = 0;
    private void Update()
    {
        if (transform.position.y < GameOptionMemorizer.OutOfScreenYPos) RemovePooledObject();
        t += Time.deltaTime / GameOptionMemorizer.Instance.noteSpeed;
        
        //#todo : ������ �߰��Ǹ� ���� ����� ������ ������� ���� ��Ʈ�� �����̵���(������ ���ܵ� ��ũ�� �и��� �ʵ���) �ٲٱ�
        transform.position = new Vector3(
            transform.position.x, 
            Lerp(_startYPos, _endYPos, t), 
            transform.position.z);
    }
    Single Lerp(Single p1, Single p2, Single d1)
    {
        return (1 - d1) * p1 + d1 * p2;
    }

    public override void SpawnNote(int num, float timing, float otherInfo)
    {
        _startYPos = GameOptionMemorizer.StartLineYPos + (GameOptionMemorizer.Instance.UserNoteSpeed - 1.0f);
        _endYPos = GameOptionMemorizer.EndLineYPos;
        t = timing - (GameOptionMemorizer.Instance.songTime + GameOptionMemorizer.Instance.noteSpeed); //��ġ ����
    }
}