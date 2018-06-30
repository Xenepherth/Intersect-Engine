﻿using System;
using Intersect.Collections;

namespace Intersect.GameObjects.Maps.MapList
{
    public class MapListMap : MapListItem, IComparable<MapListMap>
    {
        public int MapNum = -1;

        public MapListMap() : base()
        {
            Name = "New Map";
            Type = 1;
        }

        public int CompareTo(MapListMap obj)
        {
            return MapNum.CompareTo(obj.MapNum);
        }

        public void GetData(ByteBuffer myBuffer, DatabaseObjectLookup gameMaps)
        {
            base.GetData(myBuffer);
            myBuffer.WriteInteger(MapNum);
            myBuffer.WriteString(gameMaps[MapNum]?.Name ?? "Deleted");
        }

        public bool Load(ByteBuffer myBuffer, DatabaseObjectLookup gameMaps, bool isServer = true)
        {
            base.Load(myBuffer);
            MapNum = myBuffer.ReadInteger();
            Name = myBuffer.ReadString();
            if (isServer)
            {
                if (!gameMaps.IndexKeys.Contains(MapNum)) return false;
            }
            else
            {
                if (gameMaps.IndexKeys.Contains(MapNum))
                {
                    gameMaps[MapNum].Name = Name;
                }
            }
            return true;
        }
    }
}