using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterMoney : MonoBehaviour
{
    public static string Convert(ulong money)
    {
        int i = 0;
        float RealMoney = (float)money;
        for (; RealMoney >= 1000;)
        {
            i++;
            RealMoney /= 1000;
        }

        switch (i)
        {
            case 1: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "a";
            case 2: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "b";
            case 3: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "c";
            case 4: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "d";
            case 5: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "e";
            case 6: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "f";
            case 7: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "g";
            case 8: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "h";
            case 9: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "i";
            case 10: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "j";
            case 11: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "k";
            case 12: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "l";
            case 13: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "m";
            case 14: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "n";
            case 15: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "o";
            case 16: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "p";
            case 17: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "q";
            case 18: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "r";
            case 19: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "s";
            case 20: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "t";
            case 21: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "u";
            case 22: return MathF.Round(RealMoney, 2, MidpointRounding.ToEven) + "v";
            default: return money.ToString();
        }

    }
}
