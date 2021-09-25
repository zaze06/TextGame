﻿using System;

public class Map
{
	public Map()
	{
	}

    internal static int[,] map(int v)
    {
        switch (v){
            case 0: return new int[20,20]
                {
                    { 7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                    { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                    { 7,7,7,7,7,7,7,0,7,7,7,7,7,7,7,7,7,7,0,7},
                    { 7,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,7,0,7},
                    { 7,0,7,7,7,7,7,7,7,0,7,7,7,7,7,7,0,0,0,7},
                    { 7,0,0,0,0,0,0,0,7,0,0,0,0,0,0,7,7,7,7,7},
                    { 7,7,7,7,7,7,7,0,7,7,7,7,7,7,0,7,0,0,0,7},
                    { 7,0,0,0,0,0,0,0,7,0,0,0,0,7,0,0,0,7,0,7},
                    { 7,0,7,7,7,7,7,7,7,7,7,7,0,7,7,7,7,7,0,7},
                    { 7,0,7,0,0,0,0,7,0,0,0,7,0,0,0,0,0,7,0,7},
                    { 7,0,7,0,0,0,0,7,0,7,0,7,7,7,7,7,0,7,0,7},
                    { 7,0,7,7,7,7,7,7,0,7,0,0,0,0,0,7,0,7,0,7},
                    { 7,0,7,0,0,0,0,0,0,7,7,7,7,7,0,7,0,7,0,7},
                    { 7,0,7,0,7,7,7,7,7,7,0,0,0,0,0,7,0,0,0,7},
                    { 7,0,7,0,0,0,0,0,7,7,0,7,7,7,7,7,7,7,7,7},
                    { 7,0,7,7,7,7,7,0,7,7,0,0,0,0,0,0,0,0,0,7},
                    { 7,0,7,0,0,0,0,0,7,7,7,7,7,7,7,7,7,7,0,7},
                    { 7,0,7,0,7,7,7,7,7,7,0,0,0,0,0,0,0,7,0,7},
                    { 7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,7,9,7},
                    { 7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                };
            case 1: /*Game.Game.setEndPos(16,18);*/return new int[20,20]
                {
                    {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                    {7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                    {7,7,0,7,7,7,7,0,7,7,7,7,7,7,7,7,7,7,0,7},
                    {7,0,0,0,7,7,7,8,0,0,0,0,0,0,0,0,0,7,0,7},
                    {7,0,0,0,0,0,7,7,7,7,7,7,7,7,0,7,0,7,0,7},
                    {7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,7,0,7,0,7},
                    {7,0,0,0,7,7,7,7,7,7,7,7,7,7,7,7,0,7,0,7},
                    {7,0,0,0,7,8,0,0,0,0,0,0,0,0,0,7,0,7,0,7},
                    {7,0,0,0,7,7,7,7,7,7,7,7,7,7,0,7,0,7,0,7},
                    {7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,7,0,0,0,7},
                    {7,0,0,0,7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                    {7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                    {7,0,0,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0,7},
                    {7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                    {7,0,0,0,7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                    {7,0,0,0,7,0,7,0,0,0,7,7,7,7,7,7,7,7,7,7},
                    {7,0,0,0,7,0,0,0,7,0,0,0,0,0,0,0,0,0,9,7},
                    {7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                    {7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                    {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                };
            case 2: return new int[20,20]
                {
                    {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                    {7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                    {7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0,7},
                    {7,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,7},
                    {7,0,7,0,7,7,7,7,7,7,7,7,7,7,7,7,0,7,0,7},
                    {7,0,7,0,7,0,0,0,0,0,0,0,0,0,0,7,0,7,0,7},
                    {7,0,7,0,7,0,7,7,7,7,7,7,7,7,0,7,0,7,0,7},
                    {7,0,7,0,7,0,7,0,0,0,0,0,0,7,0,7,0,7,0,7},
                    {7,0,7,0,7,0,7,0,7,7,7,7,0,7,0,7,0,7,0,7},
                    {7,0,7,0,7,0,7,0,7,7,7,7,0,7,0,7,0,7,0,7},
                    {7,0,7,0,7,0,7,0,11,0,8,7,0,7,0,7,0,7,0,7},
                    {7,0,7,0,7,0,7,7,7,7,7,7,0,7,0,7,0,7,0,7},
                    {7,0,7,0,7,0,0,0,0,0,0,0,0,7,0,7,0,7,0,7},
                    {7,0,7,0,7,7,7,7,7,7,7,7,7,7,0,7,0,7,9,7},
                    {7,0,7,0,0,0,0,0,0,0,0,0,0,0,0,7,0,7,7,7},
                    {7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0,7,8,7},
                    {7,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,7},
                    {7,0,7,7,0,7,7,7,7,7,7,7,7,7,7,7,7,11,0,7},
                    {7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7},
                    {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                };
            case 3: return new int[20,20]
                {
                    {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                    {7,0,0,0,0,0,0,0,12,0,12,0,0,0,0,7,0,0,0,7},
                    {7,0,7,7,7,7,7,13,7,13,7,7,7,7,0,7,0,0,0,7},
                    {7,14,7,7,7,7,7,0,7,0,7,0,0,7,0,7,0,0,0,7},
                    {7,0,12,0,0,0,11,0,7,0,7,0,0,7,0,7,0,0,0,7},
                    {7,0,7,7,7,13,7,7,7,0,7,7,7,7,0,7,0,0,0,7},
                    {7,0,11,0,12,0,7,0,11,0,12,0,7,7,0,7,0,0,0,7},
                    {7,7,7,14,7,0,7,0,7,7,7,0,7,7,0,7,0,0,0,7},
                    {7,0,11,0,7,0,7,0,7,8,0,0,7,7,0,7,0,0,0,7},
                    {7,13,7,14,7,13,7,13,7,7,7,7,7,7,13,7,7,7,7,7},
                    {7,0,12,0,11,0,0,0,0,0,11,0,0,0,0,0,0,0,0,7},
                    {7,7,7,14,7,7,7,7,7,14,7,7,7,7,7,7,7,7,7,7},
                    {0,0,0,0,0,0,11,0,7,0,0,0,0,0,0,0,11,0,7,7},
                    {13,7,7,7,7,7,7,0,7,7,7,7,7,7,7,7,7,0,0,7},
                    {0,7,0,0,0,0,11,0,7,6,6,6,6,6,7,0,11,0,7,7},
                    {0,7,13,7,7,7,7,0,7,6,6,6,6,6,7,0,7,7,7,7},
                    {0,7,0,7,7,0,11,0,7,6,6,6,6,6,7,0,7,8,7,7},
                    {13,7,13,7,7,13,7,14,7,7,7,7,7,7,7,0,7,0,7,7},
                    {0,0,0,0,0,0,12,0,0,0,0,0,0,0,0,0,7,9,7,7},
                    {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                };
            case 4: return new int[20, 20]
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,7,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,0}
                };
            default: return new int[20, 20];
        }
    }
}
