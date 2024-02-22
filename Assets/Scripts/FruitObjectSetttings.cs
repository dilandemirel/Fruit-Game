using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create FruitObjectSetting", fileName = "FruitObjectSetting", order = 0)]
public class FruitObjectSettting : ScriptableObject
{
    [SerializeField] private FruitObject prefab;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<float> scales;

    public FruitObject SpawnObject => prefab; //prefabi referans verir
    public Sprite GetSprite(int index)
    {
        if (index < 0 || index >= sprites.Count)
        {
            Debug.LogError(message: "Out of Range!");
        }

        return sprites[index];
    }

    public float GetScale(int index)
    {
        if(index<0 || index>=scales.Count)
        {
            Debug.LogError(message: "Out of Range!");
        }

        return scales[index];
    }
}
