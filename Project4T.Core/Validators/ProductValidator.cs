﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4T.DataAccess.Repository;
using Project4T.Models;

namespace Project4T.Core.Validators
{
    public static class ProductValidator
    {
        private static IRepository<Product> _repo;
        public static bool ValidateInput(string name, decimal price)
        {
            if (name.Length==0 || name.Length>30)
            {
                return false;
            }
            if (price < 0)
            {
                return false;
            }
            return true;
        }
        public static bool ProductExists(int id)
        {
            if (_repo.Get(id)==null)
            {
                return false;
            }
            return true;
        }
    }
}
