using System;
using StudentLibrary;
//using GregsUtilitiesLibrary;

namespace LibraryProject {

    class Program {

        static void Main(string[] args) {

            var lib = new StudentLib();

            // add elmer fudd
            var ef = new Student {
                Id = 0, Firstname = "Elmer", Lastname = "Fudd",
                Sat = 600, Gpa = 1.5, IsFulltime = true, MajorId = 1
            };
            var ok = lib.InsertStudent(ef);
            Console.WriteLine(ef);
            Console.WriteLine((ok ? "Insert Successful!" : "Insert Failed!"));

            // update elmer fudd
            var elmerfudd = lib.GetStudent(ef.Id);
            if(elmerfudd == null) {
                throw new Exception("Student not found!");
            }
            elmerfudd.Firstname = "Johnny";
            var success = lib.UpdateStudent(elmerfudd);
            Console.WriteLine(elmerfudd);
            Console.WriteLine((success ? "Update Successful!" : "Update Failed!"));

            // remove elmer fudd
            var ef1 = new Student { Id = ef.Id };
            var rc = lib.DeleteStudent(ef);
            Console.WriteLine(ef1);
            Console.WriteLine((rc ? "Delete Successful!" : "Delete Failed!"));


            //// get list of all students
            //var students = lib.ListStudents();

            //foreach(var student in students) {
            //    Console.WriteLine($"{student.Firstname} {student.Lastname} {student.Major?.Description}");
            //}
            //// get a student by primary key
            //// this should work
            //var s4 = lib.GetStudent(2);
            //if(s4 == null) {
            //    Console.WriteLine("Student not found!");
            //} else {
            //    Console.WriteLine($"S4: {s4.Firstname} {s4.Lastname} {s4.Major.Description}");
            //}
            //// this should fail
            //var s444 = lib.GetStudent(444);
            //if(s444 == null) {
            //    Console.WriteLine("Student not found!");
            //} else {
            //    Console.WriteLine($"S444: {s444.Firstname} {s444.Lastname} {s444.Major.Description}");
            //}
        }
    }
}
