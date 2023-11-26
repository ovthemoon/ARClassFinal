using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int PlayerExp { get; private set; }
    public int PlayerLevel { get; private set; }
    public int PlayerMaxHp { get; private set; }
    public int Money { get; private set; }

    [SerializeField]
    private int[] expMax;
    void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        // 데이터 불러오기
        PlayerExp = PlayerPrefs.GetInt("PlayerExp", 0);
        PlayerLevel = PlayerPrefs.GetInt("PlayerLevel", 1);
        PlayerMaxHp = PlayerPrefs.GetInt("PlayerMaxHp", 5);
        Money = PlayerPrefs.GetInt("Money", 0);
    }
    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
        PlayerPrefs.Save();

    }
    public void SaveData()
    {
        // 데이터 저장하기
        PlayerPrefs.SetInt("PlayerExp", PlayerExp);
        PlayerPrefs.SetInt("PlayerLevel", PlayerLevel);
        PlayerPrefs.SetInt("PlayerMaxHp", PlayerMaxHp);
        PlayerPrefs.SetInt("Money", Money);

        PlayerPrefs.Save();
    }

    // 데이터 업데이트 예시 함수
    public void UpdateExp(int exp)
    {
        PlayerExp += exp;
        // 필요한 경우 다른 로직 추가
        if(PlayerExp >= expMax[PlayerLevel - 1])
        {
            UpdateLevelUp();
        }
        SaveData();
    }
    public void UpdateLevelUp()
    {
        PlayerExp = PlayerExp - expMax[PlayerLevel - 1];
        PlayerLevel++;
    }

    public void UpdateLevel(int level)
    {
        PlayerLevel = level;
        SaveData();
    }

    public void UpdateMaxHp(int maxHp)
    {
        PlayerMaxHp = maxHp;
        SaveData();
    }

    public void UpdateMoney(int money)
    {
        Money += money;
        SaveData();
    }
}
