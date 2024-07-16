﻿using MessagePack;

namespace Intersect.Network.Packets.Client;

[MessagePackObject]
public partial class ActivateEventPacket : IntersectPacket
{
    //Parameterless Constructor for MessagePack
    public ActivateEventPacket()
    {

    }

    public ActivateEventPacket(Guid eventId)
    {
        EventId = eventId;
    }

    [Key(0)]
    public Guid EventId { get; set; }

}
