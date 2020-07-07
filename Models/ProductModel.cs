using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListClient.Models
{
    public class ProductModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public StoreDepartments Department { get; set; } = (StoreDepartments)1;


        [Required]
        public int Quantity { get; set; } = 1;

        public bool Current { get; set; } = true;

        public bool IsDone { get; set; } = false;


    }

}
