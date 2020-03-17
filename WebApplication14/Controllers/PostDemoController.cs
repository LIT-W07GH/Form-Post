using System;
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            PeopleDb db = new PeopleDb(_connectionString);
            db.Delete(id);
            return Redirect("/postdemo/showpeople");
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

//Second Exercise:

//Add a column to your table called "Delete". In each row of the table, there
//should be a delete button, that when clicked, will delete that person from the
//database, and redirect the user back to the page that shows a list of all people.
//The way to achieve this is to embed each Delete button in a form that posts
//to an Action on your controller that will delete that person. Inside that form,
//also have a hidden input with the id of that person. Then, in your controller,
//take that id in as a parameter, delete that person, and then redirect back to
//the list page.

//<input type="hidden" name="id" value="some id" />