using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//# perintah untuk compiler, tidak diekskusi umumnya
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;  // Input field untuk nama
    public Button startButton;    // Button untuk mulai

    void Start()
    {
        // Ketika button di-click, jalankan function StartGame
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // Ambil nama dari input field
        string nama = nameInput.text;

        // Cek apakah nama kosong
        if (string.IsNullOrEmpty(nama))
        {
            Debug.Log("Nama masih kosong!");
            return; // Jangan lanjut kalau kosong
        }

        // Simpan nama ke PlayerPrefs (storage Unity)
        PlayerPrefs.SetString("PlayerName", nama);
        PlayerPrefs.Save();

        Debug.Log("Nama tersimpan: " + nama);

        // Pindah ke scene Game
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
                    Application.Quit(); // original code to quit Unity player
        #endif
    }
}
