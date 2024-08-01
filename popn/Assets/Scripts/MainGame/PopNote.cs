using System;
using UnityEngine;

public class PopNote : MonoPooledObject
{
    private Single _startYPos = 0;
    private Single _endYPos = 0;
    private Single t = 0;
    private void OnEnable()
    {
        _startYPos = transform.position.y;
        _endYPos = GameOptionMemorizer.EndLineYPos;
        t = 0;
    }
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

}