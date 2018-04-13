using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_AVLStudent.Model
{
    public class Student : IComparable
    {
        private int id;
        private string name;
        private float avgMark;
        private int accumulationCredit;
        private DateTime birthDay;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float AvgMark { get => avgMark; set => avgMark = value; }
        public int AccumulationCredit { get => accumulationCredit; set => accumulationCredit = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }

        public Student()
        {

        }

        public Student(int id, string name, DateTime birth, float avg, int accumulationCredit)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDay = birth;
            this.AvgMark = avg;
            this.AccumulationCredit = accumulationCredit;
        }

        public override string ToString()
        {
            return $"ID :{Id} ;Name: {Name};BirthDay: {BirthDay.ToString("dd/MM/yyyy")};AvgMark: {AvgMark};AccumulationCredit: {AccumulationCredit}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            try
            {

                var stu = obj as Student;
                return this.Id == stu.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int CompareTo(object obj)
        {
            try
            {
                var node = obj as Student;
                return this.Id.CompareTo(node.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
