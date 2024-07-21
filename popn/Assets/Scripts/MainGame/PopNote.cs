using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopNote : MonoBehaviour
{
    
    public void SpawnSetting(Int32 keyNumber, Single timing)
    {
        transform.position = new Vector3(
            GameOptionMemorizer.FirstLineXPosition + ((keyNumber - 1) * GameOptionMemorizer.LineSpace),

            GameOptionMemorizer.EndLineYPos // ������ �ʹ� ��������;
            + ((timing - GameOptionMemorizer.Instance.songTime)
            * GameOptionMemorizer.NoteSpeedMultiple * GameOptionMemorizer.Instance.noteSpeed),

            0);

    }
    //#todo : PopNoteSpawner���Լ� Ÿ�̹��� �Է¹޴´�.
}
/*
�����̸ƽ��� �����غ� ���, ��Ʈ�� Ÿ�ֺ̹��� 3.5�� ���� �����ȴ�.
�׸��� �ӵ��� ���� �����Ǵ� ��ġ�� ���̰� �޶�����. 

���� ���� 5.5
�� ���� -2
��� �� ��, �ʼ� x * N�� �ӵ��� �̵��ϴ� ��Ʈ��
A�ʿ� ��Ȯ�� ���������� �̵��� ���Ѿ��ϸ� ���� B���� ��Ȳ�̴�.
�̶�, B���� �� ��Ʈ�� ���̸� ���Ͽ���

yPos = -2 + ((A - B) * GameOptionMemorizer.NoteSpeedMultiple * N)

�̶� (A - B)�� 3.5���� ��Ȳ�̰� N�� 1�� �� NoteSpeedMultiple�� ���ϸ� ��

5.5 = -2 + (3.5 * G.N * 1)
7.5 = 3.5 * G.N
GameOptionMemorizer.NoteSpeedMultiple = 2.142857 (������)
 */