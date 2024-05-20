using UnityEngine;
public class CursorController : MonoBehaviour
{
    public Texture2D cursorTexture; // La textura del cursor que quieres usar

    void Start()
    {
        // Cambia el cursor a la textura especificada
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}