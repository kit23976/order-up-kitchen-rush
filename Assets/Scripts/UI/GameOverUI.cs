using System.Collections;
using Unity.Netcode;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Dan.Demo;  // เพิ่มบรรทัดนี้

public class GameOverUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI recipesDeliveredText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private LeaderboardShowcase leaderboardShowcase; // Reference to LeaderboardShowcase
        [SerializeField] private Canvas gameOverCanvas;  // เพิ่ม Canvas ของ UI
    [SerializeField] private GameObject deliveryManagerUI;  // เพิ่มตัวแปรสำหรับ DeliveryManagerUI


    private void Awake() {
        playAgainButton.onClick.AddListener(() => {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
{
    if (KitchenGameManager.Instance.IsGameOver())
    {
        Show();

        int successfulRecipes = DeliveryManager.Instance.GetSuccessfulRecipesAmount();
        recipesDeliveredText.text = successfulRecipes.ToString();

        // Update the score in LeaderboardShowcase
        leaderboardShowcase.UpdatePlayerScore(successfulRecipes);  // อัพเดตคะแนน

        // Submit the score to Leaderboard
        leaderboardShowcase.Submit();  // ส่งคะแนนไปที่ Leaderboard
    }
    else
    {
        Hide();
    }
}

    private void Show() {
        gameObject.SetActive(true);
                gameOverCanvas.gameObject.SetActive(true);  // แสดง Canvas
                deliveryManagerUI.SetActive(false);  // ซ่อน DeliveryManagerUI


        playAgainButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
                gameOverCanvas.gameObject.SetActive(false); // ซ่อน Canvas
                deliveryManagerUI.SetActive(true);  // ซ่อน DeliveryManagerUI


    }
}