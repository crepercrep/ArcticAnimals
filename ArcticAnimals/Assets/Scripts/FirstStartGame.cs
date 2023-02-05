using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStartGame : MonoBehaviour
{
    private void Start()
    {
        if (!GlobalVar.First) return;
        long DTnow = DateTime.Now.Ticks / 10000000;
        int HoursAbsence = (int)((DTnow - GlobalVar.TimeLastExit) / 3600);
        for (int i = 0; i < GlobalVar.SumAnimals; i++)
        {
            if (GlobalVar.ReproductionAnimal[i] > 0)
            {
                long lovenow = (GlobalVar.LoveAnimal[i] - DTnow) / 864;
                if (lovenow < 0) lovenow = 0;
                float Love = (float)lovenow / 2400.0f;
                int NewPopulation = (int)(GlobalVar.PopulAnimal[i]*Math.Exp(HoursAbsence*Love));
                GlobalVar.PopulAnimal[i] = NewPopulation;
            }
        }
        GlobalVar.First = false;
    }
}
