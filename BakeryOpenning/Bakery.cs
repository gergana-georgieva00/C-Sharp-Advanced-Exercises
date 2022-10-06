using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>();
        }

        public List<Employee> Employees { get { return employees; } set { employees = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Employees.Count; } }

        public void Add(Employee employee)
        {
            if (this.Employees.Count < this.Capacity)
            {
                this.Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (this.Employees.Any(e => e.Name == name))
            {
                this.Employees = this.Employees.Where(e => e.Name != name).ToList();
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = this.Employees.OrderByDescending(e => e.Age).ToList()[0];
            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = this.Employees.Where(e => e.Name == name).ToList()[0];
            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            sb.AppendLine($"{string.Join(Environment.NewLine, this.Employees)}");

            return sb.ToString();
        }
    }
}
