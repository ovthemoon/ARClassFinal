using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    using System;
    using UnityEngine;
    public struct DungeonInfo
    {
        public (float latitude, float longitude) gps;
        public float spawnTime;
        public int dungeonLevel;
        public int monsterCount;
        // Constructor for easy initialization
        public DungeonInfo((float latitude, float longitude) gps, float time, int level, int count)
        {
            this.gps = gps;
            spawnTime = time;
            dungeonLevel = level;
            monsterCount = count;
        }
    }

    public class DummyManager : MonoBehaviour
    {
        public (float latitude, float longitude)[] gpsList;

        public DungeonInfo[] dungeon = new DungeonInfo[5];

        // Start is called before the first frame update
        void Start()
        {
            dungeon[0] = new DungeonInfo((37.791231f,127.123242f), 1, 0, 10);
            //0Àº º¸½º
            for (int i = 1; i < dungeon.Length; i++)
            {
                dungeon[i] = new DungeonInfo((37.791231f+(float)0.0001*i, 127.123242f+ (float)0.0001 * i), 1, i, 10);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
