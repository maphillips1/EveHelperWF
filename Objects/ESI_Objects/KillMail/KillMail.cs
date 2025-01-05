using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.ESI_Objects.KillMail
{
    public class ESI_KillMail
    {
        public List<Attacker> attackers { get; set; }
        public long killmail_id { get; set; }    
        public DateTime killmail_time { get; set; }
        public long solar_system_id { get; set; }
        public Victim victim { get; set; }
    }

    public class Attacker
    {
        public long alliance_id { get; set; }
        public long character_id { get; set; }
        public long corporation_id { get; set; }
        public int damage_done { get; set; }
        public bool final_blow { get; set; }
        public double security_status { get; set; }
        public long ship_type_id { get; set; }
        public long weapon_type_id   { get; set; }
        public long? faction_id { get; set; } // Optional property
    }

    public class Victim
    {
        public long alliance_id { get; set; }
        public long character_id { get; set; }
        public long corporation_id { get; set; }
        public int damage_taken { get; set; }
        public List<Item> items { get; set; }
        public Position position { get; set; }
        public int ship_type_id { get; set; }
    }

    public class Item
    {
        public int flag { get; set; }
        public long item_type_id { get; set; }
        public int quantity_dropped { get; set; }
        public int? quantity_destroyed { get; set; } // Optional property
        public int singleton { get; set; }
    }

    public class Position
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }
}
