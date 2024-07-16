﻿using Intersect.Enums;
using MessagePack;

namespace Intersect.Network.Packets.Server;

[MessagePackObject]
public partial class EntityLeftPacket : IntersectPacket
{
    //Parameterless Constructor for MessagePack
    public EntityLeftPacket()
    {
    }

    public EntityLeftPacket(Guid id, EntityType type, Guid mapId)
    {
        Id = id;
        Type = type;
        MapId = mapId;
    }

    [Key(0)]
    public Guid Id { get; set; }

    [Key(1)]
    public EntityType Type { get; set; }

    [Key(2)]
    public Guid MapId { get; set; }

}
