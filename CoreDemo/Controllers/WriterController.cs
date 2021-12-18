﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            var result = wm.TGetById(1);
            return View(result);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ChangePassword(Writer p )
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEdit()
        {
            var result =  wm.TGetById(1);
            return View(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEdit(Writer writer)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(writer);
            if (results.IsValid   )
            {
                writer.Status = true;
                writer.Image = "test";
                wm.TUpdate(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
           
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddWriterImgDto dto) // model kullan +
        {

            Writer w = new Writer();
            if (dto.Image != null)
            {
                var extension = Path.GetExtension(dto.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                dto.Image.CopyTo(stream);
                w.Image = newImageName;

            }
            w.Mail = dto.Mail;
            w.Name = dto.Name;
            w.Password = dto.Password;
            w.About = dto.About;
            w.Phone = dto.Phone;
            w.City = dto.City;
            w.Gender = dto.Gender;
            w.Status = true;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

        [AllowAnonymous]
        public IActionResult WriterNavbarPartial()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult WriterFooterPartial()
        {
            return View();
        }


    }
}
