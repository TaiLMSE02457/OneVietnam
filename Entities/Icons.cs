using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Runtime.Versioning;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities
{
    public class Icons : BaseEntity
    {
        public int Type { get; set; }
        public byte[] Icon { get; set; }
        public string Name { get; set; }

        public Icons()
        {
        }

        public Icons(int type, byte[] icon, string name)
        {
            Type = type;
            Icon = icon;
            Name = name;
        }

    }
}
