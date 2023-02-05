using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textlng : MonoBehaviour
{
    private void Awake()
    {
        if (!(GlobalVar.FirstsWorkingNow < GlobalVar.FirstsWorkingNeed)) return;
        
        //add("", "", "");
        add("Play", "", "������");
        add("Settings", "", "���������");
        add("Exit", "", "�����");
        add("Language", "", "����");
        add("SaveManager", "Save Manager", "�������� ����������");
        add("TakeSave", "Take Save", "�������� ����������");
        add("CopySave", "Copy Save", "����������� ����������");
        add("LoadSave", "Load Save", "��������� ����������");
        add("AreYS", "Are you sure?", "�� �������?");
        add("Yes", "", "��");
        add("No", "", "���");
        add("EnterSave", "Enter Save...", "������� ����������...");
        add("CopiedTC", "Copied to clipboard!", "����������� � ����� ������!");
        add("Back", "", "�����");
        add("BtnBack", "Back", "�����");
        add("Description", "", "��������");
        add("DNA:", "", "���:");
        add("Matter:", "", "�������:");
        add("Take", "", "�����");
        add("Synthesize", "", "�������������");
        add("Maintenance", "", "������������");
        add("Feed", "", "�������");
        add("Minerals ", "", "��������");
        add("Oxygen", "", "��������");
        add("BtnApply", "Apply", "�������");
        add("Population:", "", "���������:");
        add("ConservationS", "Conservation Status:", "�������� ������:");
        add("Mine", "", "�����");
        add("EnterTM", "Enter the mine", "����� � �����");
        add("ExitTM", "Exit the mine", "����� �� �����");
        add("Collapse", "", "�����");
        add("ERROR", "", "������"); 
        add("Animallimit", "Animal limit", "����� ��������");
        add("AnimallimitDesc", "animals can be on your screen, no more", "�������� ����� ���� �� ����� ������, �� ������"); 
        add("Reproduction", "", "�����������");
        add("SwitchedOn", "Switched on", "��������");
        add("SwitchedOff", "Switched off", "���������");
        add("TitleMine", "|Mine|", "|�����|"); 
        add("TitleSynt", "|Synthesis Center|", "|����� �������|"); 
        add("TitlePurpose", "|Purposes|", "|����|");
        add("Purposes", "", "����"); 
        add("Get", "", "��������");
        add("Received", "", "��������");
        add("ProductionPH", "Production Per Hour:", "������ � ���:"); 
        add("Forfeit", "", "�����");
        add("AnimalSatiety:", "Animal Satiety:", "������� ��������:");
        add("Collapses:", "Collapses:", "������:");
        add("Research", "", "������������");
        add("CheckRR", "Check Research Results", "��������� ���������� ������������");
        add("ResultsAI", "Results Are Incorrect", "���������� �����������"); 
        add("MaintenanceCR", "Maintenance Code Received", "��� ����������� �������");
        add("TitleManual", "|Manual|", "|����������|");
        add("Manual", "", "����������");

        add("Purpose0", "Have a total population of over 10 individuals", "����� ����� ��������� ����� 10 ������");
        add("Purpose1", "Have a total population of over 25 individuals", "����� ����� ��������� ����� 25 ������");
        add("Purpose2", "Have a total population of over 100 individuals", "����� ����� ��������� ����� 100 ������");
        add("Purpose3", "Have a total population of over 500 individuals", "����� ����� ��������� ����� 500 ������");
        add("Purpose4", "Have a total population of over 1000 individuals", "����� ����� ��������� ����� 1000 ������");

        add("Purpose5", "Have a stoat population of over 25 individuals", "����� ��������� ���������� ����� 10 ������");
        add("Purpose6", "Have a stoat population of over 100 individuals", "����� ��������� ���������� ����� 100 ������");
        add("Purpose7", "Have a stoat population of over 250 individuals", "����� ��������� ���������� ����� 250 ������");

        add("Purpose8", "Have a population of Arctic foxes over 25 individuals", "����� ��������� ������ ����� 25 ������");
        add("Purpose9", "Have a population of Arctic foxes over 100 individuals", "����� ��������� ������ ����� 100 ������");
        add("Purpose10", "Have a population of Arctic foxes over 250 individuals", "����� ��������� ������ ����� 250 ������");

        add("Purpose11", "Have a population of Snow sheep 25 individuals", "����� ��������� ������� ������� ����� 25 ������");
        add("Purpose12", "Have a population of Snow sheep 100 individuals", "����� ��������� ������� ������� 100 ������");
        add("Purpose13", "Have a population of Snow sheep over 250 individuals", "����� ��������� ������� ������� 250 ������");

        add("Purpose14", "Have at least one individual in each population", "����� ��� ������� ���� ����� ����� ������ ���������");

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
