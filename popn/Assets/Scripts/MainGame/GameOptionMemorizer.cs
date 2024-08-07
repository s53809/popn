using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptionMemorizer : MonoSingleton<GameOptionMemorizer>
{
    //���
    public static readonly Single FirstLineXPosition = -3.2f;
    public static readonly Single LineSpace = 0.8f;
    public static readonly Single StartLineYPos = 5f;
    public static readonly Single EndLineYPos = -2f;
    public static readonly Single OutOfScreenYPos = -5f;

    //������ ���� ���� �� ������ �� �ִ� ����
    public Single UserNoteSpeed { get; private set; }

    //ä������ �ܺ��� �������� ���Ͽ� ���� ���� �ִ� �ΰ��� �Ӽ�
    public Single noteSpeed = 1f;
    public Single songTime;

    public void Initialization(Single userNoteSpeed)
    {
        this.UserNoteSpeed = userNoteSpeed;
    }

    protected override void Awake()
    {
        base.Awake();
        UserNoteSpeed = 1.0f;
        
    }

    [InspectorButton("Hell")]
    public void ChangeUserSpeed()
    {
        if (UserNoteSpeed == 1.0f) UserNoteSpeed = 7.0f;
        else UserNoteSpeed = 1.0f;
    }

    private void Start()
    {
        songTime = 0;
    }

    private void Update()
    {
        songTime += Time.deltaTime; // �ӽ� �ڵ�
    }
}
//#todo : ���� ������ ����(ĳ���� ����ȭ��, �� ���� ȭ��, �ΰ��� ȭ�� ���)�� �� �� �ִ� ������ ���� �����