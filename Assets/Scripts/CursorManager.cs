    using UnityEngine;

public class CursorManager : MonoBehaviour
{
    //Texture2D là một lớp (class) trong Unity, dùng để lưu trữ hình ảnh 2D (texture).
    //hotspot = điểm “nhọn” trong ảnh con trỏ (nơi thực sự click vào).
    //(16, 48) là tọa độ pixel trong ảnh (x = 16, y = 48).
    //Khi Unity hiển thị cursor, nó dùng điểm hotspot này làm gốc con trỏ.
//Input.GetMouseButtonDown(0) → Khi người chơi nhấn chuột trái (bắt đầu bắn)
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReLoad;
    private Vector2 hotspot = new Vector2(16, 48);
      void Start()
    {
        Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorShoot, hotspot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(cursorReLoad, hotspot, CursorMode.Auto);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
        }
    }
}
