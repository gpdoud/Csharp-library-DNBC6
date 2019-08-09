using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLibrary {

    public class StudentLib {

        public static string About = "About StudentLib";

        public List<Student> ListStudents() {
            var db = new AppEfDbContext();
            return db.Students.ToList();
        }
        public Student GetStudent(int id) {
            var db = new AppEfDbContext();
            return db.Students.Find(id);
        }
        public bool InsertStudent(Student s) {
            var db = new AppEfDbContext();
            s.Id = 0;
            if(s.MajorId != null) {
                var major = db.Majors.Find(s.MajorId);
                if(major == null) {
                    return false;
                }
            }
            db.Students.Add(s);
            db.SaveChanges();
            return true;
        }
        public bool DeleteStudent(Student s) {
            var db = new AppEfDbContext();
            var sDB = GetStudent(s.Id);
            if(sDB == null) {
                return false;
            }
            db.Students.Remove(sDB);
            db.SaveChanges();
            return true;
        }
        public bool UpdateStudent(Student s) {
            var db = new AppEfDbContext();
            var sDB = GetStudent(s.Id);
            if(sDB == null) {
                throw new Exception("Student cannot be found!");
            }
            sDB.Firstname = s.Firstname;
            sDB.Lastname = s.Lastname;
            sDB.Gpa = s.Gpa;
            sDB.Sat = s.Sat;
            sDB.IsFulltime = s.IsFulltime;
            sDB.MajorId = s.MajorId;
            if(s.MajorId != null) {
                var major = db.Majors.Find(s.MajorId);
                if(major == null) {
                    return false;
                }
            }
            //db.Update<Student>(sDB);
            db.Students.Update(sDB);
            db.SaveChanges();
            return true;

        }

    }
}
