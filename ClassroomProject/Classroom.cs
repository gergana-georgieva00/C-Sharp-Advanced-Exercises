using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.Students = new List<Student>();
        }

        public List<Student> Students { get { return students; } set { students = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count { get { return this.Students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (this.Students.Count < this.Capacity)
            {
                this.Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.Students.Any(s => s.FirstName == firstName))
            {
                this.Students = this.Students.Where(s => s.FirstName != firstName).ToList();
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> filtered = this.Students.Where(s => s.Subject == subject).ToList();

            if (filtered.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            for (int i = 0; i < filtered.Count; i++)
            {
                if (i < filtered.Count - 1)
                {
                    sb.AppendLine($"{filtered[i].FirstName} {filtered[i].LastName}");
                }
                else
                {
                    sb.Append($"{filtered[i].FirstName} {filtered[i].LastName}");
                }
            }

            return sb.ToString();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = this.Students.Find(s => s.FirstName == firstName && s.LastName == lastName);

            return student;
        }
    }
}
