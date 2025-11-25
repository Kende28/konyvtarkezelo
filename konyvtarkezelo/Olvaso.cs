using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtarkezelo
{
    internal class Olvaso
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public List<string> Notifications { get; set; } = new List<string>();
        public string Membership { get; set; }

        public Olvaso(string name, int age, string genre, List<string> notification, string membership) {
            Name = name;
            Age = age;
            Genre = genre;
            Notifications = notification;
            Membership = membership;
        }

        public override string ToString()
        {
            string notif = string.Join(",", Notifications);
            return $"{Name};{Age};{Genre};{notif};{Membership};";
        }
    }
}
