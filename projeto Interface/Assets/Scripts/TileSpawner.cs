using UnityEngine;
using System.Collections.Generic;

public class TileSpawner : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform[] lanes; // 4 pistas
    public AudioSource musica;
    public TextAsset levelData;

    private List<Note> notes = new List<Note>();
    private float startTime;

    void Start()
    {
        CarregarFase();
        startTime = Time.time;
        musica.Play();
    }

    void Update()
    {
        float tempoMusica = Time.time - startTime;

        foreach (Note nota in new List<Note>(notes))
        {
            if (tempoMusica >= nota.tempo - 2f) // Gera 2 segundos antes
            {
                Vector3 posicaoInicial = lanes[nota.lane].position + new Vector3(0, 10, 0);
                Instantiate(tilePrefab, posicaoInicial, Quaternion.identity);
                notes.Remove(nota);
            }
        }
    }

    void CarregarFase()
    {
        string[] linhas = levelData.text.Split('\n');
        foreach (string linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha)) continue;

            string[] partes = linha.Split(',');
            float tempo = float.Parse(partes[0].Trim());
            int lane = int.Parse(partes[1].Trim());
            notes.Add(new Note { tempo = tempo, lane = lane });
        }
    }

    class Note
    {
        public float tempo;
        public int lane;
    }
}
