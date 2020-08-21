using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class CharacterSelectionScreen : MonoBehaviour
{

    [HideInInspector]
    public UnityEngine.Vector2 slotArtworkSize;

    public static CharacterSelectionScreen instance;

    [Header("Characters List")]
    public List<SelectableCharacter> selectableCharacters = new List<SelectableCharacter>();
    [Space]
    [Header("Public Referances")]
    public GameObject characterCellPrefab;
    public Transform playerSlotsContainer;
    [Space]
    [Header("Current confirmed character")]
    public SelectableCharacter confirmedCharacter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach (SelectableCharacter selectableCharacter in selectableCharacters)
        {
            SpawnCharacterCell(selectableCharacter);
        }

        slotArtworkSize = playerSlotsContainer.GetChild(0).Find("Artwork").GetComponent<RectTransform>().sizeDelta;

    }

    private void SpawnCharacterCell(SelectableCharacter selectableCharacter)
    {
        GameObject characterCell = Instantiate(characterCellPrefab, transform);
        characterCell.name = selectableCharacter.characterName;

        Image artwork = characterCell.transform.Find("CharacterArtwork").GetComponent<Image>();
        TextMeshProUGUI name = characterCell.transform.Find("CharacterNameText").GetComponentInChildren<TextMeshProUGUI>();

        artwork.sprite = selectableCharacter.characterSprite;
        name.text = selectableCharacter.characterName;

        UnityEngine.Vector2 pixelSize = new UnityEngine.Vector2(artwork.sprite.texture.width, artwork.sprite.texture.height);
        UnityEngine.Vector2 pixelPivot = artwork.sprite.pivot;

        artwork.GetComponent<RectTransform>().pivot = uiPivot(artwork.sprite);
        artwork.GetComponent<RectTransform>().sizeDelta *= selectableCharacter.zoom;
    }

    public void ShowCharacterInSlot(int player, SelectableCharacter character)
    {
        bool nullChar = (character == null);

        Color alpha = nullChar ? Color.clear : Color.white;
        Sprite artwork = nullChar ? null : character.characterSprite;
        string name = nullChar ? string.Empty : character.characterName;
        string playerNickname = nullChar ? string.Empty : "Player" + (player + 1).ToString();
        string playerNumber = nullChar ? string.Empty : "P" + player.ToString();

        Transform slot = playerSlotsContainer.GetChild(player);

        Transform slotArtwork = slot.Find("Artwork");

        Sequence s = DOTween.Sequence();
        s.Append(slotArtwork.DOLocalMoveX(-300, .05f).SetEase(Ease.OutCubic));
        s.AppendCallback(() => slotArtwork.GetComponent<Image>().sprite = artwork);
        s.AppendCallback(() => slotArtwork.GetComponent<Image>().color = alpha);
        s.Append(slotArtwork.DOLocalMoveX(300, 0));
        s.Append(slotArtwork.DOLocalMoveX(0, 0.5f).SetEase(Ease.OutCubic));

        if (artwork != null)
        {
            slotArtwork.GetComponent<RectTransform>().pivot = uiPivot(artwork);
            slotArtwork.GetComponent<RectTransform>().sizeDelta = slotArtworkSize;
            slotArtwork.GetComponent<RectTransform>().sizeDelta *= character.zoom;
        }


        slot.Find("Artwork").GetComponent<Image>().sprite = artwork;
        slot.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
        slot.Find("Player").GetComponentInChildren<TextMeshProUGUI>().text = playerNickname;
        slot.Find("IconAndPx").GetComponentInChildren<TextMeshProUGUI>().text = playerNumber;
    }

    public void ConfirmCharacter(int player, SelectableCharacter character)
    {
        
        //if(confirmedCharacter == null)
        //{
            confirmedCharacter = character;
            playerSlotsContainer.GetChild(player).DOPunchPosition(UnityEngine.Vector3.down, 20, 1);
            Debug.Log("Player " + (player + 1) + " has confirmed selected character " + character.name);
        //}
        
    }

    public UnityEngine.Vector2 uiPivot (Sprite sprite)
    {
        UnityEngine.Vector2 pixelSize = new UnityEngine.Vector2(sprite.texture.width, sprite.texture.height);
        UnityEngine.Vector2 pixelPivot = sprite.pivot;
        return new UnityEngine.Vector2(pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);

    }

}
