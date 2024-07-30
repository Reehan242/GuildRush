using UnityEngine;
using UnityEngine.UI;

public class SaveNama : MonoBehaviour
{
    public string NamaPlayer;
    public string SaveNamaPlayer;
    [SerializeField] public Text TxtInput;
    [SerializeField] public Text LoadNama;

    void Start()
    {
        NamaPlayer = PlayerPrefs.GetString("NamaPlayer", "TEXT");
        LoadNama.text = NamaPlayer;
    }

    void Update()
    {
        Start();
    }

    public void MasukanPlayer()
    {
        SaveNamaPlayer = TxtInput.text;
        PlayerPrefs.SetString("NamaPlayer", SaveNamaPlayer);
    }
}

