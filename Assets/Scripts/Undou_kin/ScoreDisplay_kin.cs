using UnityEngine;
using TMPro;

public class ScoreDisplay_kin : MonoBehaviour
{
    // Unity Editorで割り当てる、新しいスコア表示用のTextコンポーネント
    public TextMeshProUGUI scoreText;

    // シーン内のGameController_kinへの参照
    private GameController_kin gameController;

    void Start()
    {
        // GameController_kinのインスタンスを探して取得する
        gameController = Object.FindFirstObjectByType<GameController_kin>();

        if (scoreText == null)
        {
            Debug.LogError("ScoreDisplay_kin: Score Text is not assigned.");
        }

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
        }
    }
    // Update→LateUpdate

    void LateUpdate()
    {

        if (gameController != null && scoreText != null)
        {
            // GameController_kinのpublicプロパティ CurrentScore を使ってスコアを参照
            int currentScoreValue = gameController.CurrentScore - 10;

            // 常に正しい形式でスコアを上書き表示し続けます
            scoreText.text = "現在のスコア: " + currentScoreValue.ToString();

            // 念のため、表示オブジェクトが非アクティブ化されていないか毎フレーム確認し、アクティブに戻します。
            if (!scoreText.gameObject.activeInHierarchy)
            {
                scoreText.gameObject.SetActive(true);
            }
        }
    }
}