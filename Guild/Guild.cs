using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>();
        }

        public List<Player> Roster { get { return roster; } set { roster = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (this.Roster.Count < this.Capacity)
            {
                this.Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.Roster.Any(p => p.Name == name))
            {
                this.Roster = this.Roster.Where(p => p.Name != name).ToList();
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var player = this.Roster.Where(p => p.Name == name).ToList()[0];

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var player = this.Roster.Where(p => p.Name == name).ToList()[0];

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classs)
        {
            var filtered = this.Roster.Where(p => p.Class == classs).ToList();
            this.Roster = this.Roster.Where(p => p.Class != classs).ToList();
            return filtered.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            for (int i = 0; i < Roster.Count; i++)
            {
                if (i == Roster.Count - 1)
                {
                    sb.Append(Roster[i].ToString());
                }
                else
                {
                    sb.AppendLine(Roster[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
