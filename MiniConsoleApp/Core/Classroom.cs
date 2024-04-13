using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Classroom
    {
        private static int _id;
        public int Id { get; set; }

        public string Name { get; set; }


        public ClassType Type { get; set; }


        public Classroom(string name, ClassType type)
        {
            _id++;
            Id = _id;
            Name = name;
            Type = type;

        }

        Student[] _students = new Student[] { };

        public Student this[int index] 
        { 
            get 
            { 
                return _students[index];
            } 
        }

        public int Length
        {
            get { return _students.Length; }
        }

        public void StudentAdd(Student student)
        {
            Array.Resize(ref _students, _students.Length + 1);
            _students[_students.Length - 1] = student;
        }

        public void Delete(int id)
        {
            bool checkStudent = false;
            Student[] newstudents = { };

            for(int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Id != id)
                {
                    Array.Resize(ref newstudents, newstudents.Length + 1);
                    newstudents[newstudents.Length - 1] = _students[i];
                }
                else
                {
                    checkStudent = true;
                }
            }

            if(!checkStudent)
            {
                throw new StudentNotFoundException("Verilmis id olan telebe yoxdur");
            }
            _students = newstudents;
        }


        public Student[] FindId(int id)
        {
            Student[] studentsId = { };

            for(int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Id == id)
                {
                    Array.Resize(ref studentsId, studentsId.Length + 1);
                    studentsId[studentsId.Length - 1] = _students[i];
                }
            }
            return studentsId;
        }

        public Student[] GetAllStudents()
        {
            return _students;
        }

        public override string ToString()
        {
            return  $"Id: {Id}, Name: {Name}";
        }

    }
}
