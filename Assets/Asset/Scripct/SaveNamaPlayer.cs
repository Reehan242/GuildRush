using UnityEngine;
using TMPro;

public class SaveNamaPlayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NamaTxt;
    [SerializeField] TextMeshProUGUI displayNama;

    void Start()
    {
        NamaTxt.text = PlayerPrefs.GetString("NamaPlayer");
    }

    public void MasukanPlayer()
    {
        NamaTxt.text = displayNama.text;
        PlayerPrefs.SetString("NamaPlayer", NamaTxt.text);
        PlayerPrefs.Save();
    }
}
