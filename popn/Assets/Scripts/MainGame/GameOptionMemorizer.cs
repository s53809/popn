using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptionMemorizer : MonoSingleton<GameOptionMemorizer>
{
    //상수
    public static readonly Single NoteSpeedMultiple = 2.142857f;
    public static readonly Single FirstLineXPosition = -3.2f;
    public static readonly Single LineSpace = 0.8f;
    public static readonly Single EndLineYPos = -2f;

    //유저가 게임 시작 전 설정할 수 있는 변수
    public Single UserNoteSpeed { get; private set; }

    //채보같은 외부적 요인으로 인하여 변할 수도 있는 인게임 속성
    public Single noteSpeed;
    public Single songTime;

    public void Initialization(Single userNoteSpeed)
    {
        this.UserNoteSpeed = userNoteSpeed;
    }

    protected override void Awake()
    {
        base.Awake();
        
    }
}
//#todo : 현재 게임의 상태(캐릭터 선택화면, 곡 선택 화면, 인게임 화면 등등)를 알 수 있는 옵저버 패턴 만들기