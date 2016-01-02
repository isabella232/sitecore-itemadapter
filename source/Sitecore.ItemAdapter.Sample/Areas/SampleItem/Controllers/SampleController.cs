﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.ItemAdapter.Sample.Areas.SampleItem.Controllers
{
    public class SampleController : Controller
    {
        private static readonly Guid contentItemId = new Guid("{0DE95AE4-41AB-4D01-9EB0-67441B7C2450}");

        // GET: SampleItem/Sitecore
        public ActionResult Index()
        {
            Item item = Context.Database.GetItem(new ID(contentItemId));
            Item[] contentChildren = item.Children.Where(c => c.TemplateID.Guid.Equals(Models.SampleItem.SampleItemTemplateId)).ToArray();
            var sampleItemList = StandardItemAdapter<Models.SampleItem>.GetEnumerator(contentChildren);
            return Json(sampleItemList, JsonRequestBehavior.AllowGet);
        }

        // GET: SampleItem/Sitecore/Details/5
        public ActionResult Details(Guid id)
        {
            Sitecore.Data.Items.Item item = Context.Database.GetItem(new ID(id));
            var sampleItem = StandardItemAdapter<Models.SampleItem>.GetExtendedModel(item, 1);
            return Json(sampleItem, JsonRequestBehavior.AllowGet);
        }


        // POST: SampleItem/Sitecore/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Sitecore.Data.Items.Item item = Context.Database.GetItem(new ID(id));
                var sampleItem = StandardItemAdapter<Models.SampleItem>.GetExtendedModel(item, 1);
                var updateItem = new Models.SampleItem();
                updateItem.SetId(id);

                if (collection["Title"] != null)
                {
                    updateItem.Title = collection["Title"];
                }
                if (collection["Text"] != null)
                {
                    updateItem.Text = collection["Text"];
                }

                StandardItemAdapter<Models.SampleItem>.SaveModel(updateItem, item);

                return RedirectToAction("Details", new { @id = id });

            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditModel(Guid id, [System.Web.Http.FromBody]Models.SampleItem model)
        {
            Sitecore.Data.Items.Item item = Context.Database.GetItem(new ID(id));
            var sampleItem = StandardItemAdapter<Models.SampleItem>.GetExtendedModel(item, 1);
            var updateItem = new Models.SampleItem();
            updateItem.SetId(id);

            if (model.Title != null)
            {
                updateItem.Title = model.Title;
            }
            if (model.Text != null)
            {
                updateItem.Text = model.Text;
            }

            StandardItemAdapter<Models.SampleItem>.SaveModel(updateItem, item);

            return RedirectToAction("Details", new { @id = id });
        }


        // GET: SampleItem/Sitecore/Create
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        // POST: SampleItem/Sitecore/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                throw new NotImplementedException();

                return RedirectToAction("Index");
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // GET: SampleItem/Sitecore/Edit/5
        public ActionResult Edit(Guid id)
        {
            throw new NotImplementedException();
        }

        // GET: SampleItem/Sitecore/Delete/5
        public ActionResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        // POST: SampleItem/Sitecore/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                throw new NotImplementedException();

                return RedirectToAction("Index");
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
