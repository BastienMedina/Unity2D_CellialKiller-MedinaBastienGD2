using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BestCounts", menuName = "Scriptable Objects/BestCounts")]
public class BestCounts : ScriptableObject
{
    public Dictionary<string, int> scores;

    public void AddScore(string key, int value) //Ajoute ou met à jour le meilleur score
    {
        if (scores.ContainsKey(key)) //Si la clé existe déjà
        {
            if (scores[key] < value) //Si le nouveau score est meilleur
            {
                scores[key] = value;
            }
        }
        else
        {
            scores.Add(key, value);
        }
    }
}
