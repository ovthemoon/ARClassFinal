using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public struct DungeonInfo
{
    public (float latitude, float longitude) gps;
    public float spawnTime;
    public int dungeonLevel;
    public int monsterCount;
    public bool isEnableEntrance;
    // Constructor for easy initialization
    public DungeonInfo((float latitude, float longitude) gps, float time, int level, int count, bool enable)
    {
        this.gps = gps;
        spawnTime = time;
        dungeonLevel = level;
        monsterCount = count;
        isEnableEntrance = enable;
    }
}

public class DummyManager : Singleton<DummyManager>
{
    public (float latitude, float longitude)[] gpsList;

    public DungeonInfo[] dungeon = new DungeonInfo[5];
    //입장 가능한 gps의 범위
    private float distance = 10;
    // Start is called before the first frame update
    void Start()
    {
    Debug.Log("Succesfullt screated");
        dungeon[0] = new DungeonInfo((37.791231f,127.123242f), 1, 0, 10,false);
        //0은 보스
        for (int i = 1; i < dungeon.Length; i++)
        {
            //약간의 오프셋 설정을 위해 0.0001을 곱해줌
            dungeon[i] = new DungeonInfo((37.791231f+(float)0.0001*i, 127.123242f+ (float)0.0001 * i), 1, i, 10+5*i-1,false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dungeon.Length; i++)
        {
        //GPS를 받아오지 못하는경우(테스트용)
        if (GPS_Manager.Instance!=null)
            {
                dungeon[i].isEnableEntrance = true;
            }
            else
            {
                double currentDistanceToDungeon = CalculateDistance(GPS_Manager.Instance.latitude, GPS_Manager.Instance.longitude,
                dungeon[i].gps.latitude, dungeon[i].gps.longitude);
                if (currentDistanceToDungeon < distance)
                {
                    dungeon[i].isEnableEntrance = true;
                }
                    
            }

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
}

