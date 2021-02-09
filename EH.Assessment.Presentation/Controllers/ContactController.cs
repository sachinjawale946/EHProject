using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EH.Assessment.Data;
using EH.Assessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace EH.Assessment.Presentation.Controllers
{
    public class ContactController : Controller
    {
        readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult All()
        {
            if (TempData["SuccessMessage"] != null && !string.IsNullOrEmpty(TempData["SuccessMessage"].ToString()))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            return View();
        }

        public IActionResult ReadContacts(string draw, string start, int length)
        {
            // Sort Column Name  
            var sortColumn = Request.Query["columns[" + Request.Query["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            // Sort Column Direction ( asc ,desc)  
            var sortColumnDirection = Request.Query["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)  
            var searchValue = Request.Query["search[value]"].FirstOrDefault();

            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            // Getting all Customer data  
            var contacts = _contactRepository.GetAll().Where(c => c.Status == true);

            //Sorting  
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                var sortValue = typeof(ContactModel).GetProperty(sortColumn);
                if (sortColumnDirection == "asc")
                    contacts = contacts.OrderBy(c => sortValue.GetValue(c, null));
                else
                    contacts = contacts.OrderByDescending(c => sortValue.GetValue(c, null));
            }
            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                contacts = contacts.Where(m => m.FirstName.Contains(searchValue) || m.LastName.Contains(searchValue) || m.Email.Contains(searchValue) || m.Phone.Contains(searchValue));
            }

            //total number of rows count   
            recordsTotal = contacts.Count();
            //Paging   
            var data = contacts.Skip(skip).Take(length).ToList();
            //Returning Json Data  
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Manage", new ContactModel() { Mode = "Add", Status = true });
        }

        [HttpPost]
        public IActionResult Add(ContactModel contactModel)
        {
            // add contact 
            _contactRepository.Add(contactModel);
            TempData["SuccessMessage"] = "Contact created successfully";
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(Guid contactId)
        {
            var contact = _contactRepository.GetContactById(contactId);
            contact.Mode = "Edit";
            return View("Manage", contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contactModel)
        {
            _contactRepository.Update(contactModel);
            TempData["SuccessMessage"] = "Contact updated successfully";
            return RedirectToAction("All");
        }

        public IActionResult Delete(Guid contactId)
        {
            var contact = _contactRepository.GetContactById(contactId);
            contact.Status = false;
            _contactRepository.Update(contact);
            return Content("Contact deactivated successfully");
        }

        public JsonResult IsExists(string fieldType, string fieldValue, Guid? contactId)
        {
            var contact = _contactRepository.GetContactByFieldAndValue(fieldType, fieldValue, contactId);
            if (contact != null && contact.ContactId != Guid.Empty) return Json("true");
            return Json("false");
        }
    }
}