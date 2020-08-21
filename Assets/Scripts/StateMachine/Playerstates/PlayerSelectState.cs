using UnityEngine;

public class PlayerSelectState : IState
{
    private GameObject _cursor;
    private GameObject _playerSelectedSlot;
    public PlayerSelectState(GameObject cursor, GameObject playerSelectedSlot)
    {
        _cursor = cursor;
        _playerSelectedSlot = playerSelectedSlot;
    }
    public void OnEnter()
    {
        _cursor.SetActive(true);
        _playerSelectedSlot.SetActive(true);
        Debug.Log("Activating Cursor (PlayerSelectState)");
    }

    public void OnExit()
    {
        _cursor.SetActive(false);
        _playerSelectedSlot.SetActive(false);
    }

    public void Tick()
    {

    }

}
