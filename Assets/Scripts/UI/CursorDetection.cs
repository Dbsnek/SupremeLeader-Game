using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorDetection : MonoBehaviour
{
    private GraphicRaycaster graphicRaycaster;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public PlayerInput_KE input;
    private int playerNumber;

    public Transform currentCharacter;

    Vector2 cursorPos;

    public bool characterIsSelected;

    void Start()
    {
        graphicRaycaster = GetComponentInParent<GraphicRaycaster>();
        input.OnButtonPressed += Input_OnButtonPressed;
        playerNumber = transform.GetComponentInParent<PlayerPanel>().playerNumber;
    }

    private void Input_OnButtonPressed(string button)
    {
        if(button == "Abutton")
        {
            if (currentCharacter != null)
            {
                HasCharacterSelected(true);
                CharacterSelectionScreen.instance.ConfirmCharacter(playerNumber - 1, CharacterSelectionScreen.instance.selectableCharacters[currentCharacter.GetSiblingIndex()]);
                var player = GetComponentInParent<PlayerPanel>().player;
                player.character = currentCharacter.name;
            }
        }
        if (button == "Xbutton")
        {
            CharacterSelectionScreen.instance.confirmedCharacter = null;
            HasCharacterSelected(false);
        }
    }

    void Update()
    {
        cursorPos = transform.position;
        pointerEventData.position = cursorPos;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        if(!characterIsSelected)
        {
            if (results.Count > 0)
            {
                Transform raycastCharacter = results[0].gameObject.transform;

                if (raycastCharacter != currentCharacter)
                {
                    SetCurrentCharacter(raycastCharacter);
                }
            }
        }
    }

    void SetCurrentCharacter(Transform t)
    {
        currentCharacter = t;

        if(t != null)
        {
            int index = t.GetSiblingIndex();
            SelectableCharacter character = CharacterSelectionScreen.instance.selectableCharacters[index];
            CharacterSelectionScreen.instance.ShowCharacterInSlot(playerNumber - 1, character);
        }
        else
        {
            CharacterSelectionScreen.instance.ShowCharacterInSlot(playerNumber - 1, null);
        }
    }

    void HasCharacterSelected(bool trigger)
    {
        characterIsSelected = trigger;
    }
}
