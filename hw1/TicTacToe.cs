using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    public int[,] board = new int[3, 3]; // 创建一个 3 * 3 大小的棋盘
    public int step = 0; // 记录走的步数
    void Start() // 此为重置棋盘的函数，刚开始游戏时便重置
    {
        init();
    }

    void init() // 此为重置棋盘的函数
    {
        step = 0;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = 0; // 如果棋盘上的数字为0代表当前的位置为空的 
    }

    int isWin() // 判断是否已经有人获胜，并且返回获胜方
    {
        // 判断玩家1获胜的条件
        if (board[0, 0] == 1 && board[0, 1] == 1 && board[0, 2] == 1) return 1;
        if (board[1, 0] == 1 && board[1, 1] == 1 && board[1, 2] == 1) return 1;
        if (board[0, 0] == 1 && board[1, 0] == 1 && board[2, 0] == 1) return 1;
        if (board[0, 1] == 1 && board[1, 1] == 1 && board[2, 1] == 1) return 1;
        if (board[0, 2] == 1 && board[1, 2] == 1 && board[2, 2] == 1) return 1;
        if (board[2, 0] == 1 && board[2, 1] == 1 && board[2, 2] == 1) return 1;
        if (board[0, 0] == 1 && board[1, 1] == 1 && board[2, 2] == 1) return 1;
        if (board[0, 2] == 1 && board[1, 1] == 1 && board[2, 0] == 1) return 1;
        // 判断玩家2获胜的条件
        if (board[0, 0] == 2 && board[0, 1] == 2 && board[0, 2] == 2) return 2;
        if (board[1, 0] == 2 && board[1, 1] == 2 && board[1, 2] == 2) return 2;
        if (board[0, 0] == 2 && board[1, 0] == 2 && board[2, 0] == 2) return 2;
        if (board[0, 1] == 2 && board[1, 1] == 2 && board[2, 1] == 2) return 2;
        if (board[0, 2] == 2 && board[1, 2] == 2 && board[2, 2] == 2) return 2;
        if (board[2, 0] == 2 && board[2, 1] == 2 && board[2, 2] == 2) return 2;
        if (board[0, 0] == 2 && board[1, 1] == 2 && board[2, 2] == 2) return 2;
        if (board[0, 2] == 2 && board[1, 1] == 2 && board[2, 0] == 2) return 2;
        // 并没有玩家获胜
        return 0;
    }

    void OnGUI() // 下的每一步棋子
    {
        // 点击reset按钮进行重置棋盘的操作
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 50, 40), "reset"))
        {
            init();
            return;
        }
        // 井字棋的名称
        GUI.TextField(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 75, 20), "Tic Tac Toe");
        // 判断是否有人获胜
        int flag = isWin();
        if (flag == 1)
        {
            GUI.TextField(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 75, 20), "Player1 Win!!!");
        }
        else if (flag == 2)
        {
            GUI.TextField(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 75, 20), "Player2 Win!!!");
        }
        else if (step == 9)
        {
            GUI.TextField(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 75, 20), "Play even!!!");
        }
        else
        {
            // 每一步按钮该进行的操作
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        if (GUI.Button(new Rect(Screen.width / 2 - 70 + i * 40, Screen.height / 2 - 50 + j * 40, 40, 40), ""))
                        {
                            if (step % 2 == 0)
                            {
                                board[i, j] = 1;
                            }
                            else
                            {
                                board[i, j] = 2;
                            }
                            step++;
                        }
                    }
                    else if (board[i, j] == 1) GUI.Button(new Rect(Screen.width / 2 - 70 + i * 40, Screen.height / 2 - 50 + j * 40, 40, 40), "X");
                    else GUI.Button(new Rect(Screen.width / 2 - 70 + i * 40, Screen.height / 2 - 50 + j * 40, 40, 40), "O");
                }
            }
        }
    }
    
}