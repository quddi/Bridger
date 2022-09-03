using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreTextLoader : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = string.Format($"Best score: {Serializer.GameData.BestScore}");
    }
}
