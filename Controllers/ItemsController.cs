using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {

        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        // [HttpPost("/items")]
        // public ActionResult Create()
        // {
        //   Item newItem = new Item(Request.Form["itemDescription"]);
        //   //newItem.Save();
        //   List<Item> allItems = Item.GetAll();
        //   return View("Index", allItems);
        // }


      //   [HttpPost("/items")]
      //  public ActionResult Create(string itemDescription)
      //  {
      //      Item newItem = new Item(itemDescription);
      //      List<Item> allItems = Item.GetAll();
      //      return View("Index", allItems);
      //  }

      // [HttpPost("/items")]
      //   public ActionResult Create(string description)
      //   {
      //     Item newItem = new Item(description);
      //     newItem.Save();
      //     List<Item> allItems = Item.GetAll();
      //     return RedirectToAction("Index");
      //   }

       [HttpGet("/items/{id}")]
      public ActionResult Details(int id)
      {
          Item item = Item.Find(id);
          return View(item);
      }


        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
            Item.DeleteAll();
            return View();
        }


        [HttpGet("/categories/{categoryId}/items/new")]
       public ActionResult CreateForm(int categoryId)
       {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(categoryId);
          return View(category);
       }
       [HttpGet("/categories/{categoryId}/items/{itemId}")]
       public ActionResult Details(int categoryId, int itemId)
       {
          Item item = Item.Find(itemId);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(categoryId);
          model.Add("item", item);
          model.Add("category", category);
          return View(item);
       }



       [HttpGet("/items/{id}/update")]
       public ActionResult UpdateForm(int id)
       {
           Item thisItem = Item.Find(id);
           return View(thisItem);
       }

       [HttpPost("/items/{id}/update")]
        public ActionResult Update(int id, string newDescription)
        {
            Item thisItem = Item.Find(id);
            thisItem.Edit(newDescription);
            return RedirectToAction("Index");
        }

    }
}
