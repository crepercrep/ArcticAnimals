using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textlng : MonoBehaviour
{
    private void Awake()
    {
        if (!(GlobalVar.FirstsWorkingNow < GlobalVar.FirstsWorkingNeed)) return;
        
        //add("", "", "");
        add("Play", "", "Играть");
        add("Settings", "", "Настройки");
        add("Exit", "", "Выход");
        add("Language", "", "Язык");
        add("SaveManager", "Save Manager", "Менеджер сохранений");
        add("TakeSave", "Take Save", "Получить сохранение");
        add("CopySave", "Copy Save", "Скопировать сохранение");
        add("LoadSave", "Load Save", "Загрузить сохранение");
        add("AreYS", "Are you sure?", "Вы уверены?");
        add("Yes", "", "Да");
        add("No", "", "Нет");
        add("EnterSave", "Enter Save...", "Введите сохранение...");
        add("CopiedTC", "Copied to clipboard!", "Скопировано в буфер обмена!");
        add("Back", "", "Назад");
        add("BtnBack", "Back", "Назад");
        add("Description", "", "Описание");
        add("DNA:", "", "ДНК:");
        add("Matter:", "", "Материя:");
        add("Take", "", "Взять");
        add("Synthesize", "", "Синтезировать");
        add("Maintenance", "", "Обслуживание");
        add("Feed", "", "Кормить");
        add("Minerals ", "", "Минералы");
        add("Oxygen", "", "Кислород");
        add("BtnApply", "Apply", "Принять");
        add("Population:", "", "Популяция:");
        add("ConservationS", "Conservation Status:", "Охранный статус:");
        add("Mine", "", "Шахта");
        add("EnterTM", "Enter the mine", "Войти в шахту");
        add("ExitTM", "Exit the mine", "Выйти из шахты");
        add("Collapse", "", "Обвал");
        add("ERROR", "", "ОШИБКА"); 
        add("Animallimit", "Animal limit", "Лимит животных");
        add("AnimallimitDesc", "animals can be on your screen, no more", "животных может быть на вашем экране, не больше"); 
        add("Reproduction", "", "Размножение");
        add("SwitchedOn", "Switched on", "Включено");
        add("SwitchedOff", "Switched off", "Выключено");
        add("TitleMine", "|Mine|", "|Шахта|"); 
        add("TitleSynt", "|Synthesis Center|", "|Центр синтеза|"); 
        add("TitlePurpose", "|Purposes|", "|Цели|");
        add("Purposes", "", "Цели"); 
        add("Get", "", "Получить");
        add("Received", "", "Получено");
        add("ProductionPH", "Production Per Hour:", "Добыча в час:"); 
        add("Forfeit", "", "Штраф");
        add("AnimalSatiety:", "Animal Satiety:", "Сытость Животных:");
        add("Collapses:", "Collapses:", "Обвалы:");
        add("Research", "", "Исследование");
        add("CheckRR", "Check Research Results", "Проверить Результаты Исследования");
        add("ResultsAI", "Results Are Incorrect", "Результаты некорректны"); 
        add("MaintenanceCR", "Maintenance Code Received", "Код обсуживания получен");
        add("TitleManual", "|Manual|", "|Справочник|");
        add("Manual", "", "Справочник");

        add("Purpose0", "Have a total population of over 10 individuals", "Иметь общую популяцию свыше 10 особей");
        add("Purpose1", "Have a total population of over 25 individuals", "Иметь общую популяцию свыше 25 особей");
        add("Purpose2", "Have a total population of over 100 individuals", "Иметь общую популяцию свыше 100 особей");
        add("Purpose3", "Have a total population of over 500 individuals", "Иметь общую популяцию свыше 500 особей");
        add("Purpose4", "Have a total population of over 1000 individuals", "Иметь общую популяцию свыше 1000 особей");

        add("Purpose5", "Have a stoat population of over 25 individuals", "Иметь популяцию горностаев свыше 10 особей");
        add("Purpose6", "Have a stoat population of over 100 individuals", "Иметь популяцию горностаев свыше 100 особей");
        add("Purpose7", "Have a stoat population of over 250 individuals", "Иметь популяцию горностаев свыше 250 особей");

        add("Purpose8", "Have a population of Arctic foxes over 25 individuals", "Иметь популяцию песцов свыше 25 особей");
        add("Purpose9", "Have a population of Arctic foxes over 100 individuals", "Иметь популяцию песцов свыше 100 особей");
        add("Purpose10", "Have a population of Arctic foxes over 250 individuals", "Иметь популяцию песцов свыше 250 особей");

        add("Purpose11", "Have a population of Snow sheep 25 individuals", "Иметь популяцию снежных баранов свыше 25 особей");
        add("Purpose12", "Have a population of Snow sheep 100 individuals", "Иметь популяцию снежных баранов 100 особей");
        add("Purpose13", "Have a population of Snow sheep over 250 individuals", "Иметь популяцию снежных баранов 250 особей");

        add("Purpose14", "Have at least one individual in each population", "Иметь как минимум одну особь среди каждой популяции");

        GlobalVar.FirstsWorkingNow += 1;
    }
    private void Start()
    {
        GlobalVar.SelectText();
    }

    private void add(string id, string en, string ru)
    {
        GlobalVar.Addtext(id,en,ru);
    }

}
