using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            List<Person> sorted = this.People.OrderByDescending(p => p.Age).ToList();
            return sorted[0];
        }

        internal Family Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
