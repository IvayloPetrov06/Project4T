﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4T.DataAccess.Repository;
using Project4T.Models;

namespace Project4T.Core.Validators
{
    public static class CategoryValidator
    {
        private static IRepository<Category> _repo;
        public static bool CategoryExist(int id)
        {
            if (_repo.Get(id) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ValidateInput(string name)
        {
            if (name.Length == 0 || name.Length > 30)
            {
                return false;
            }
            return true;
        }
    }
}
