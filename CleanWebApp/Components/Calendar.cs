using System;
using Microsoft.AspNetCore.Mvc;

namespace CleanWebApp.Components
{
    public class Calendar : ViewComponent
    {
        public IViewComponentResult Invoke(string id, string name, string format, DateTime? value = null, bool required = false, string label = "")
        {
            string dateValue = value.HasValue ? value.Value.ToString(format) : format;
            var Field = new CalendarModel
            {
                Id = id,
                Label = label,
                Value = dateValue,
                Name = name,
                Format = format,
                Required = required
            };
            return View(Field);
        }
    }

    public class CalendarModel
    {
        public string Id { set; get; }
        public string Label { set; get; }
        public string Value { set; get; }
        public string Name { set; get; }
        public string Format { set; get; }
        public bool Required { set; get; }
    }
}