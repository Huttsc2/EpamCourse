﻿using EpamCourse.Development_and_Build_Tools;
using EpamCourse.Basic_of_dotnet_Framework_and_CSharp;
using EpamCourse.OOP;
using EpamCourse.Collections.Builders;
using EpamCourse.Collections.XMLWriters;
using EpamCourse.Exceptions.CarModels;
using EpamCourse.Object_Oriented_Design_Principles;
using PerformingClass = EpamCourse.Object_Oriented_Design_Principles.PerformingClass;

namespace EpamCourse
{
    public class MainClass
    {
        public static void Main()
        {
            PerformingClass performing = new PerformingClass();
            performing.AddCarsFromConsoleInput();
            //performing.AddPredefinedCars();
            performing.ExecuteCommand();
        }
    }
}
