using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
namespace Game
{
    public class UIManager : MonoBehaviour
    {
        public DummyManager dummyManager;
        private GPS_Manager gps_manager;
        float longtitude = 0;
        float latitude = 0;

        public GameObject dungeon_menu;
        public GameObject exit_menu;
        public GameObject obj;

        public TMP_Text result1;
        public TMP_Text result;

         bool inGame = false;
        [Header("EnemyState")]
        public TMP_Text totalEnemyCount;
        public TMP_Text currentKilledEnemyCount;

        [Header("PlayerInfo")]
        public Slider expBar;
        public TMP_Text playerLevel;
        public TMP_Text expPercentage;

        DungeonInfo dungeonInfo;

        //입장 가능한 gps의 범위
        private float distance = 10;
        void Start()
        {
            gps_manager = GPS_Manager.Instance;
            if (gps_manager == null)
            {
                Debug.LogError("GPS_Manager instance is not initialized.");
            }
            if (obj != null)
            {
                obj.SetActive(false);
            }

            inGame = SceneManager.GetActiveScene().name.Equals("InDungeon");
            Debug.Log(inGame);
            // Example: Access dungeon information for index 0

        }

        void Update()
        {
            SetPlayerInfo();
            if (inGame)
            {
                SetEnemyCount();
            }
            
            try
            {
                longtitude = gps_manager.longitude;
                latitude = gps_manager.latitude;
            }
            catch (Exception ex)
            {
                Debug.LogError($"An exception occurred in the Update method: {ex.Message}");
                return;
                // Optionally, you can log additional information from the exception, such as ex.StackTrace
            }
            

        }

        public void Menu_button()
        {
            dungeon_menu.SetActive(true);
        }
        private void SetPlayerInfo()
        {
            playerLevel.text= "Player Level : "+DataManager.Instance.PlayerLevel.ToString();
            expBar.minValue = 0;
            expBar.maxValue = DataManager.Instance.GetExpMax();
            expBar.value= DataManager.Instance.PlayerExp;
            expPercentage.text = ((float)expBar.value / expBar.maxValue).ToString()+" %";
        }
        private void SetEnemyCount()
        {
            totalEnemyCount.text = DungeonManager.Instance.dungeonInfo.monsterCount.ToString();
            currentKilledEnemyCount.text = GameManager.Instance.currentEnemyCount.ToString();
        }

        public void Entrance_button(int dungeonIndex)
        {
            //Dummy_Manager.DungeonInfo dungeonInfo = dummyManager.dungeon[dungeonIndex];
            // Check if the dungeonIndex is valid

            dungeonInfo = dummyManager.dungeon[dungeonIndex];


            result1.text = "Accepted";
            result.text = "Dungeon Entranced!!";
            obj.SetActive(true);
            dungeon_menu.SetActive(false);
            SceneManager.LoadScene("dungeon_scene");
            double currentDistanceToDungeon = CalculateDistance(GPS_Manager.Instance.latitude, GPS_Manager.Instance.longitude,
                dungeonInfo.gps.latitude, dungeonInfo.gps.longitude);
            if (currentDistanceToDungeon<distance)
            {

                result1.text = "Accepted";
                result.text = "Dungeon Entranced!!";
                obj.SetActive(true);
                dungeon_menu.SetActive(false);
                SceneManager.LoadScene("dungeon_scene");
            }
            else
            {
                result1.text = "Declined";
                result.text = "Dungeon Disable!!";
                obj.SetActive(true);
                //SceneManager.LoadScene("dungeon_scene");
            }
        }
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371e3; // 지구의 반지름 (미터 단위)
            var radLat1 = lat1 * Mathf.Deg2Rad; // 위도를 라디안으로 변환
            var radLat2 = lat2 * Mathf.Deg2Rad;
            var deltaLat = (lat2 - lat1) * Mathf.Deg2Rad;
            var deltaLon = (lon2 - lon1) * Mathf.Deg2Rad;

            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                    Math.Cos(radLat1) * Math.Cos(radLat2) *
                    Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = R * c; // 최종 거리 (미터 단위)
            return distance;
        }

        public void Exit_button()
        {
            exit_menu.SetActive(true);
        }

        public void Main_Scene()
        {
            SceneManager.LoadScene("gps_scene");
        }
    }
}
