using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Servify.Models
{
    public partial class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        private string _subCategory;
        public string SubCategory {
            get {
                if(_subCategory == "")
                    return null;
                return _subCategory;
            }
            set { _subCategory = value; }
        }
        public int MenuId { get; set; }
    }
}
