﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DAB_AFL2.Models;
using DAB_AFL2.Repositories;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace DAB_AFL2
{


    class Program
    {

        static void Main(string[] args)
        {
            Repository rep = new Repository();
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
                        Console.WriteLine("List all events from calendar: Enter '6'");
                        Console.WriteLine("List students assignment, with grade and who grade these: Enter 7");
                        

                        Console.WriteLine("Go back: Enter '0'");
                        int viewChoice = int.Parse(Console.ReadLine());

                        switch (viewChoice)
                        {
                            case 1:
                                Console.WriteLine("Listing all students:");
                                foreach (var student in rep.GetStudents().Result)
                                {
                                    Console.WriteLine($"StudentId: {student.StudentID} Name: {student.Name}");
                                }
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("Listing all courses:");
                                foreach (var SpecificCourse in rep.GetCourses().Result)
                                {
                                    Console.WriteLine($"CourseId: {SpecificCourse.CourseId} Course name: {SpecificCourse.CourseName}");
                                }
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.WriteLine("Enter StudentId to view courses:");
                                int studentId = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Student with id: {studentId} is enrolled in the following courses:");
                                foreach (var SpecificCourse in rep.GetCourses(studentId).Result)
                                {
                                    Console.WriteLine($"CourseId: {SpecificCourse.CourseId} Course name: {SpecificCourse.CourseName}");
                                }
                                Console.WriteLine("NOT WORKING YET");
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();

                                break;
                            case 4:
                                Console.WriteLine("enter course id");
                                int courseId = int.Parse(Console.ReadLine());
                                Course course = rep.GetCourseStudentsAndTeachers(courseId).Result;
                                if (course == null)
                                {
                                    Console.WriteLine("this course does not exist");
                                }
                                else
                                {

                                    Console.WriteLine("List of teachers:");
                                    foreach (Teacher_Courses teacher_Courses in course.Teacher_Courses)
                                    {
                                        Console.WriteLine(teacher_Courses.Teacher.Name);
                                    }

                                    Console.WriteLine("List of students:");
                                    foreach(Enrolled enrolled in course.Enrolled)
                                    {
                                        Console.WriteLine(enrolled.Student.Name);
                                    }
                                }

                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 5:

                                Console.WriteLine("NOT WORKING YET");
                                Console.WriteLine(".... PRESS ANY KEY TO CONTINUE");
                                Console.ReadKey();
                                break;
                            case 6:
                                //events
                                Console.WriteLine("Listing all events");
                                Calendar cal = rep.GetCalendar().Result;

                                if (cal.Events != null)
                                {
                                    foreach (var eventDate in cal.Events)
                                    {
                                        Console.WriteLine("Start: " + eventDate.StarTime);
                                        Console.WriteLine("End: " + eventDate.EndTime);
                                        Console.WriteLine("Description : \n" + eventDate.Description + "\n\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("The calender is empty.. No events for now"); ;
                                }
                                Console.WriteLine("Press any key to continue..");
                                Console.ReadKey();
                                break;
                            case 0:
                                break;
                        }




                        break;
                    case 2:
                        //Insert start
                        Console.WriteLine("Insert new student press, 1");
                        Console.WriteLine("Insert new course press, 2");
                        Console.WriteLine("Insert new event press, 3");
                        Console.WriteLine("Insert new Assignment, press 4");
                        Console.WriteLine("Enroll a student in a course, press 5");
                        Console.WriteLine("Grade Assignment, press 6");
                        

                        viewChoice = int.Parse(Console.ReadLine());
                        switch (viewChoice)
                        {
                            case 1:
                                //new student
                                Console.WriteLine("Write the students name");
                                string studentName = Console.ReadLine();
                                Console.WriteLine("Write the students birthdate");
                                string UserInput = Console.ReadLine();
                                DateTime birthDate = CheckIfStringIsDate(UserInput);
                                rep.InsertStudent(studentName, birthDate);
                                Console.WriteLine("success, press any key to continue..");
                                Console.ReadKey();
                                break;
                            case 2:
                                //new course
                                Console.WriteLine("Write the course name");
                                string courseName = Console.ReadLine();
                                rep.InsertCourse(courseName);
                                Console.WriteLine("success, press any key to continue..");
                                Console.ReadKey();
                                break;
                            case 3:
                                //new event
                                Console.WriteLine("Write the desciption of your event");
                                string eventName = Console.ReadLine();

                                Console.WriteLine("Write the start datetime of your event");
                                string eventDateSting = Console.ReadLine();
                                DateTime eventStartDate = CheckIfStringIsDate(eventDateSting);

                                Console.WriteLine("Write the end datetime of your event");
                                string eventEndDateSting = Console.ReadLine();
                                DateTime eventEndDate = CheckIfStringIsDate(eventEndDateSting);

                                rep.InsertEventToCalendar(eventName, eventStartDate, eventEndDate);
                                Console.WriteLine("success, press any key to continue..");
                                Console.ReadKey();
                                break;
                            case 4:
                                Console.WriteLine("Write the description of the Assignment");
                                string description = Console.ReadLine();
                                rep.AddAssignment(description);
                                Console.WriteLine("success, press any key to continue..");
                                Console.ReadKey();
                                break;
                            case 5:
                                Console.WriteLine("Write the id of the student you want to enroll");
                                int studentId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Write the id of the course you want to enroll the student in");
                                int courseId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Write the status the student has for the Course");
                                string status = Console.ReadLine();

                                rep.Enroll(courseId,studentId,status);

                                Console.WriteLine("success, press any key to continue..");
                                Console.ReadKey();
                                break;
                            case 6:
                                Console.WriteLine("Enter id of group you wish to grade");
                                int groupId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter grade");
                                int grade = int.Parse(Console.ReadLine());


                                rep.GradeGroup(groupId,grade);
                                Console.WriteLine("success, press any key to continue..");
                                Console.ReadKey();
                                break;

                            default:
                                break;

                        }
                        break;
                }







                var courseList = rep.GetCourses().Result;
                foreach (var course in courseList)
                {
                    Console.WriteLine(course.CourseName);
                }

            }
        }
        public static DateTime CheckIfStringIsDate(string userInput)
        {
            bool isDate = false;
            string date = userInput;
            DateTime birthDate = new DateTime();
            while (isDate == false)
            {
                if (DateTime.TryParse(date, out birthDate))
                {
                    isDate = true;
                }
                else
                {
                    Console.WriteLine("Not a valid date, try again");
                    date = Console.ReadLine();
                }
            }

            return birthDate;
        }
    }
}
