using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    using UnityEngine;
    public struct DungeonInfo
    {
        public float min_latitude;
        public float max_latitude;
        public float min_longitude;
        public float max_longitude;
        public float spawnTime;
        public int dungeonLevel;
        public int monsterCount;

        // Constructor for easy initialization
        public DungeonInfo(float min_lat, float max_lat, float min_lon, float max_lon, float time, int level, int count)
        {
            min_latitude = min_lat;
            max_latitude = max_lat;
            min_longitude = min_lon;
            max_longitude = max_lon;
            spawnTime = time;
            dungeonLevel = level;
            monsterCount = count;
        }
    }

    public class Dummy_Manager : MonoBehaviour
    {
        private float minlat = 37f;
        private float maxlat = 38f;
        private float minlon = 127f;
        private float maxlon = 128f;

       

        public DungeonInfo[] dungeon = new DungeonInfo[5];

        // Start is called before the first frame update
        void Start()
        {
            dungeon[0] = new DungeonInfo(41f, 42f, 131f, 132f, 1, 0, 10);
            //0Àº º¸½º
            for (int i = 1; i < dungeon.Length; i++)
            {
                dungeon[i] = new DungeonInfo(minlat++, maxlat++, minlon++, maxlon++, 1, i, 10);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
