using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    private void Awake()
    {
        Serializer.GetData();
    }
}
