using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
namespace Game
{
    public class UIManager : MonoBehaviour
    {
        public Dummy_Manager dummyManager;
        private GPS_Manager gps_manager;
        float longtitude = 0;
        float latitude = 0;

        public GameObject dungeon_menu;
        public GameObject exit_menu;
        public GameObject obj;

        public TMP_Text result1;
        public TMP_Text result;

        DungeonInfo dungeonInfo;

        void Start()
        {
            gps_manager = GPS_Manager.instance;
            if (gps_manager == null)
            {
                Debug.LogError("GPS_Manager instance is not initialized.");
            }
            if (obj != null)
            {
                obj.SetActive(false);
            }
            

            // Example: Access dungeon information for index 0

        }

        void Update()
        {

            try
            {
                longtitude = gps_manager.longtitude;
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

            if ((dungeonInfo.min_latitude <= latitude && latitude <= dungeonInfo.max_latitude) &&
                (dungeonInfo.min_longitude <= longtitude && longtitude <= dungeonInfo.max_longitude))
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
