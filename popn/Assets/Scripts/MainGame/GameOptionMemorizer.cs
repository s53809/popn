using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptionMemorizer : MonoSingleton<GameOptionMemorizer>
{
    //���
    public static readonly Single NoteSpeedMultiple = 2.142857f;
    public static readonly Single FirstLineXPosition = -3.2f;
    public static readonly Single LineSpace = 0.8f;
    public static readonly Single EndLineYPos = -2f;

    //������ ���� ���� �� ������ �� �ִ� ����
    public Single UserNoteSpeed { get; private set; }

    //ä������ �ܺ��� �������� ���Ͽ� ���� ���� �ִ� �ΰ��� �Ӽ�
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
//#todo : ���� ������ ����(ĳ���� ����ȭ��, �� ���� ȭ��, �ΰ��� ȭ�� ���)�� �� �� �ִ� ������ ���� �����