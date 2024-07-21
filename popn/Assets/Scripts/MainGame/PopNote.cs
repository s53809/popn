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

            GameOptionMemorizer.EndLineYPos // 수식이 너무 더러워요;
            + ((timing - GameOptionMemorizer.Instance.songTime)
            * GameOptionMemorizer.NoteSpeedMultiple * GameOptionMemorizer.Instance.noteSpeed),

            0);

    }
    //#todo : PopNoteSpawner에게서 타이밍을 입력받는다.
}
/*
디제이맥스로 관찰해본 결과, 노트는 타이밍보다 3.5초 전에 스폰된다.
그리고 속도에 따라 생성되는 위치의 높이가 달라진다. 

시작 지점 5.5
끝 지점 -2
라고 할 때, 초속 x * N의 속도로 이동하는 노트를
A초에 정확히 끝지점으로 이동을 시켜야하며 현재 B초인 상황이다.
이때, B초일 때 노트의 높이를 구하여라

yPos = -2 + ((A - B) * GameOptionMemorizer.NoteSpeedMultiple * N)

이때 (A - B)가 3.5초인 상황이고 N이 1일 때 NoteSpeedMultiple을 구하면 됨

5.5 = -2 + (3.5 * G.N * 1)
7.5 = 3.5 * G.N
GameOptionMemorizer.NoteSpeedMultiple = 2.142857 (ㅋㅋㅋ)
 */