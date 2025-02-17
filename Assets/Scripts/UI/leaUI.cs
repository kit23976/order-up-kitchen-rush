using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class leaUI : MonoBehaviour
{
    public Button leaderButton; // ลากปุ่มจาก Inspector มาใส่ในตัวแปรนี้

    void Start()
    {
        // ตรวจสอบว่ามีปุ่มอยู่และเพิ่ม Event Listener
        if (leaderButton != null)
        {
            leaderButton.onClick.AddListener(GoToMainMenu);
        }
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene"); // เปลี่ยนไปที่ MainMenuScene
    }
}
