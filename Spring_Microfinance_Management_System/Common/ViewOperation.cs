﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spring_Microfinance_Management_System.Common
{
    public class ViewOperation
    {
       

        /// Use
        public static List<SelectListItem> GetDropDownList(Dictionary<string, string> items, string defaultSelectKey = null)
        {
            var lst = new List<SelectListItem>();
            foreach (var dic in items)
            {
                var selectList = new SelectListItem
                {
                    Value = dic.Key,
                    Text = dic.Value
                };

                if (dic.Key == defaultSelectKey)
                {
                    selectList.Selected = true;
                }

                lst.Add(selectList);
            }

            return lst;
        }


        
    }
}