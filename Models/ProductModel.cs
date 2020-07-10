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

        

        public StoreDepartments Department { get; set; } = (StoreDepartments)1;


        [Required]
        public int Quantity { get; set; } = 1;

        public bool Current { get; set; } = true;

        public bool IsDone { get; set; } = false;

        [Required]
        [MaxLength(100)]
        private string _name { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = ToUpperFirstCase(value);             
            }
        }

        private string ToUpperFirstCase(string input)
        {
            char firstLetter = input[0];
            firstLetter = Char.ToUpper(firstLetter);
            return firstLetter + input.Substring(1);
        }

    }

}

//private int _age;

//public int Age
//{
//    get
//    {
//        return _age;
//    }

//    set
//    {
//        if (value > 0) // Check for the valid age
//        {
//            _age = value;
//        }
//    }
//}