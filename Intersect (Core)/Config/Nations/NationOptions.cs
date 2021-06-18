using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Intersect.Config.Nations
{
    /// <summary>
    /// Contains all options pertaining to nations
    /// </summary>
    public class NationOptions
    {
        /// <summary>
        /// Configures whether or not to allow guild members to attack eachother.
        /// </summary>
        public bool AllowNationMemberPvp { get; set; } = false;

        /// <summary>
        /// Configured whether the guild name should be rendered above player sprites as a tag
        /// </summary>
        public bool ShowNationNameTagsOverMembers { get; set; } = true;

        /// <summary>
        /// How often to send guild updates to members, these updates are alongside updates whenever people log in or out
        /// </summary>
        public int NationUpdateInterval = 10000;
    }
}
