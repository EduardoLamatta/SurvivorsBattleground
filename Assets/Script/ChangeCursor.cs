using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] private CursorType cursorNormal, cursorDefault;
    private PanelController panelController;
    private bool hasPaused;
    private void Start()
    {
        panelController = FindAnyObjectByType<PanelController>();
    }
    private void Update()
    {
        if (panelController.inPause && !hasPaused)
        {
            Cursor.SetCursor(cursorDefault.cursorTexture, cursorDefault.cursorHotspot, CursorMode.Auto);
        }
        else if (!panelController.inPause)
        {
            Cursor.SetCursor(cursorNormal.cursorTexture, cursorNormal.cursorHotspot, CursorMode.Auto);
        }
    }
}
