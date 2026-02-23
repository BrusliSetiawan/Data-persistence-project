using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

//Start, Quit, Username
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;


    public void SavePlayerName()
    {
        string playerName = nameInputField.text;

        // Simpan nama ke memori lokal
        PlayerPrefs.SetString("Enter name", playerName);
        PlayerPrefs.Save();

        Debug.Log("Enter name: " + playerName);
    }

    public void StartNew()
    {
        //SceneManager adalah kelas yang menangani segala sesuatu yang berkaitan dengan memuat dan membongkar adegan.
        //akan meload scene 1 (main)
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
        // hanya berfungsi di aplikasi yang sudah dibuild, bukan di editor.
        //Conditional Compiling adalah cara memerintahkan Unity untuk hanya menjalankan baris kode tertentu pada kondisi tertentu saja.
        //solusi agar bisa dibuild dan editor. (# perintah untuk compiler, tidak diekskusi umumnya)

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
                    Application.Quit(); // original code to quit Unity player
        #endif
    }
}
