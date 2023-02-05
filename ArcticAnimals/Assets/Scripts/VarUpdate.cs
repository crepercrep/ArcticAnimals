using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarUpdate : MonoBehaviour
{
    void Update()
    {
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        long hunger = 0;
        for (int i = 0; i < GlobalVar.SumAnimals; i++)
        {
            if (GlobalVar.PopulAnimal[i] > 0)
            {
                long hungertemp = (GlobalVar.HungerAnimal[i] - nowtime) / 864;

                if (hungertemp < 0) hungertemp = 0;
                if (hungertemp > 100) hungertemp = 100;

                hunger += hungertemp;
            }
            else
            {
                hunger += 51;
            }
            
        }
        if (GlobalVar.QuarryForfeitDNAFood > 0)
        {
            if ((hunger / GlobalVar.SumAnimals) > 50)
            {
                float dnaspeed = GlobalVar.QuarryDNASpeed + GlobalVar.QuarryForfeitDNAFood;
                float matterspeed = GlobalVar.QuarryMatterSpeed + GlobalVar.QuarryForfeitMatterFood;
                GlobalVar.QuarryChangeDNASpeed(dnaspeed);
                GlobalVar.QuarryChangeMatterSpeed(matterspeed);
                GlobalVar.QuarryForfeitDNAFood = 0;
                GlobalVar.QuarryForfeitMatterFood = 0;
                
            }
        }
        else
        {
            if ((hunger / GlobalVar.SumAnimals) < 51)
            {
                float DNAPart = GlobalVar.QuarryDNASpeed / 10;
                float MatterPart = GlobalVar.QuarryMatterSpeed / 10;
                GlobalVar.QuarryForfeitDNAFood = Random.Range(DNAPart*3, DNAPart*5);
                GlobalVar.QuarryForfeitMatterFood = Random.Range(MatterPart * 3, MatterPart * 5);
                float dnaspeed = GlobalVar.QuarryDNASpeed - GlobalVar.QuarryForfeitDNAFood;
                float matterspeed = GlobalVar.QuarryMatterSpeed - GlobalVar.QuarryForfeitMatterFood;
                GlobalVar.QuarryChangeDNASpeed(dnaspeed);
                GlobalVar.QuarryChangeMatterSpeed(matterspeed);
            }
        }
    }
}
