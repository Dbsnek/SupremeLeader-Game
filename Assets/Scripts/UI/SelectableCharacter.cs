using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class SelectableCharacter : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    public float zoom = 1;
}
