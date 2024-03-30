﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Chapter3.Models;
using PartyInvites.Models;

namespace Chapter3.Controllers;

public class HomeController : Controller
{
   public IActionResult Index(){
      return View();
   }    

   [HttpGet]
   public ViewResult RsvpForm(){
      return View();
   } 

   [HttpPost]
   public ViewResult RsvpForm(GuestResponse guestResponse){
     if (ModelState.IsValid) {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            } else {
                return View();
            }
   } 

    public ViewResult ListResponses() {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
}



