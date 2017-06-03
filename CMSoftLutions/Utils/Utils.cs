using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMSoftLutions.Utils
{
    public static class Utils
    {
        public static string GetErrorsModel(ModelStateDictionary modelErrors)
        {
            var errors = new List<string>();
            foreach (var item in modelErrors.Values.Where(x => x.Errors.Count > 0))
            {
                errors.Add(item.Errors.ElementAt(0).ErrorMessage.Replace(".",""));
            }
            return string.Join(", ", errors);
        }

    }
}