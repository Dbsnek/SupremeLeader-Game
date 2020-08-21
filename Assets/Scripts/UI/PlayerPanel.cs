using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    public Player player { get; private set; }
    private GameObject _cursor;
    [SerializeField] private GameObject _playerSelectedSlot;

    public Color PlayerColorBackground;
    public bool HasControllerAssigned = false;
    public int playerNumber;
    

    private void Awake()
    {
        var cursorTrans = transform.Find("Cursor");
        _cursor = cursorTrans.gameObject;
    }
    public bool IsReady()
    {
        if (!HasControllerAssigned)
            return false;

        return true;
    }

    public Player AssignController(Player player)
    {
        HasControllerAssigned = true;
        this.player = player;
        this.player.PlayerNumber = playerNumber;
        this.player.cursor = _cursor;
        this.player.playerSelectedSlot = _playerSelectedSlot;
        _cursor.GetComponent<CursorMove>().input = player.GetComponent<PlayerInput_KE>();
        _cursor.GetComponent<CursorDetection>().input = player.GetComponent<PlayerInput_KE>();
        Debug.Log("Setting panel to player " + playerNumber);
        this.player.PlayerJoined();

        return null;
    }


}
