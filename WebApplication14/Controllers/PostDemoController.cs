﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class PostDemoController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=MyFirstDb;Integrated Security=True;";
        public IActionResult ShowForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(string firstName, string lastName, int age)
        {
            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
            PeopleDb db = new PeopleDb(_connectionString);
            db.Add(person);
            return Redirect("/postdemo/showpeople");
        }

        public IActionResult ShowPeople()
        {
            PeopleDb db = new PeopleDb(_connectionString);
            return View(db.GetAll());
        }
    }
}

//Create a page that displays a list of People (or whatever interests you).
//On top of the page, have a link that says "Add Person". When this link
//is clicked, the user should be taken to a page that has a form that 
//has textboxes for firstname/lastname/age (or whatever thing you're doing).
//Beneath that, there should be a submit button. When the button is clicked,
//the person should get added to the database, and the user should be redirected
//back to the list of all the people. 