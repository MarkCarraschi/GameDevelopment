using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Ranking : MonoBehaviour {

    public static string nomeNPlayer;
    public static string rk;
    public string ValInput;
    Text text;

    private void ExportRK(int tm, string[] names, int[] scores){
        StreamWriter writer = new StreamWriter("Save.txt", true);

        using (writer)
        {
            // Escreve uma nova linha no final do arquivo
            writer.WriteLine("Tamanho:" + tm + "\n");
            for (int i = 0; i < tm; i++)
            {
                writer.WriteLine("Nome:" + names[tm] + "\n");
                writer.WriteLine("Score:" + scores[tm] + "\n");
            }
        }

        writer.Close();
    }

    private void import(int tm, string[] names, int[] scores)
    {
        int counter = 0;
        string line;

        // Read the file and display it line by line.  
        System.IO.StreamReader file = new System.IO.StreamReader("Save.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (line.Contains("Tamanho:")) tm = int.Parse(line.Replace("Tamanho:", ""));
            if (counter < tm && line.Contains("Nome:")) names[counter - 1] = line.Replace("Nome:", "");
            if (counter < tm && line.Contains("Score:")) names[counter - 2] = line.Replace("Score:", "");
            counter++;
        }

        file.Close();
    }

    private int[] Order(int[] vet,int i)
    {
        int aux;
        for (i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (vet[j] > vet[j + 1])
                {
                    aux = vet[j];
                    vet[j] = vet[j + 1];
                    vet[j + 1] = aux;
                }
            }
        }
        return vet;
    }

    // Use this for initialization
    void Start () {
        rk = "Ranking Looser Position\n\n";
        text = GetComponent<Text>();
    }

    public static void insert(string s)
    {
        rk += nomeNPlayer+": "+s+"\n";
    }
    // Update is called once per frame
    void Update () {
        text.text = rk;
    }
}
