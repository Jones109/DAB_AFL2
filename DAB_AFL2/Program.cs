using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using DAB_AFL2.Data;
using DAB_AFL2.Models;
using DAB_AFL2.Repositories;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace DAB_AFL2
{


    class Program
    {

        private static Repository rep = new Repository();

        static void Main(string[] args)
        {
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press 1 to view content");
                Console.WriteLine("Press 2 to insert content");

                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Your choices are:");
                        Console.WriteLine("List all students: Enter '1'");
                        Console.WriteLine("List all Courses: Enter '2'");
                        Console.WriteLine("List all Courses for specific student: Enter '3'");
                        Console.WriteLine("List all Students and Teachers for specific Course: Enter '4'");
                        Console.WriteLine("List Content for specific course: Enter '5'");
                        Console.WriteLine("");

                        Console.WriteLine("Go back: Enter '0'");
                        int viewChoice = int.Parse(Console.ReadLine());

                        switch (viewChoice)
                        {
                            case 1:
                                Console.WriteLine("Listing all students:");
                                foreach (var student in rep.GetStudents().Result)
                                {
                                    Console.WriteLine($"StudentId: {student.StudentID} Name: {student.Name}" );
                                }
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("Listing all courses:");
                                foreach (var course in rep.GetCourses().Result)
                                {
                                    Console.WriteLine($"CourseId: {course.CourseId} Course name: {course.CourseName}");
                                }
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.WriteLine("Enter StudentId to view courses:");
                                int studentId = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Student with id: {studentId} is enrolled in the following courses:");
                                foreach (var course in rep.GetCourses(studentId).Result)
                                {
                                    Console.WriteLine($"CourseId: {course.CourseId} Course name: {course.CourseName}");
                                }
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();

                                break;
                            case 4:
                                Console.WriteLine("NOT WORKING YET");
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 5:
                                Console.WriteLine("NOT WORKING YET");
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 0:

                                break;
                        }




                        break;
                    case 2:
                        Console.WriteLine("Your choices are:");
                        Console.WriteLine("Add student: Enter '1'");
                        Console.WriteLine("Add Course: Enter '2'");
                        Console.WriteLine("Enroll Student in Course: Enter '3'");
                        Console.WriteLine("Add Assignment: Enter '4'");
                        Console.WriteLine("Grade Assignment: Enter '5'");
                        Console.WriteLine("");

                        Console.WriteLine("Go back: Enter '0'");
                        int creationChoice = int.Parse(Console.ReadLine());

                        switch (creationChoice)
                        {
                            case 1:

                                HandleAddStudent();

                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("NOT WORKING YET");
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.WriteLine("NOT WORKING YET");
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 4:
                                Console.WriteLine("NOT WORKING YET");
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 5:
                                Console.WriteLine("NOT WORKING YET");
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 0:

                                break;

                        }

                            
                      
                        break;
                }
            }

            var courseList = rep.GetCourses().Result;
            foreach (var course in courseList)
            {
                Console.WriteLine(course.CourseName);
            }
            
        }


        private static void HandleAddStudent()
        {
            Console.WriteLine("Enter Name of the student");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter Students birthday '<YYYY-MM-DD>' (Optional)");
            string birthdayString = Console.ReadLine();
            DateTime birthday = DateTime.MinValue;
            if (birthdayString != "")
            {
                birthday = DateTime.Parse(birthdayString);
            }


            Console.WriteLine("Enter Students Enrollment Date '<YYYY-MM-DD>' (Optional)");
            string enrollmentDateString = Console.ReadLine();
            DateTime enrollmentDate = DateTime.MinValue;
            if (enrollmentDateString != "")
            {
                enrollmentDate = DateTime.Parse(enrollmentDateString);
            }


            Console.WriteLine("Enter Students Graduation Date '<YYYY-MM-DD>' (Optional)");
            string graduationDateString = Console.ReadLine();
            DateTime graduationDate = DateTime.MinValue;
            if (graduationDateString != "")
            {
                graduationDate = DateTime.Parse(graduationDateString);
            }


            rep.AddStudent(studentName, birthday, enrollmentDate, graduationDate);
        }

    }
}
