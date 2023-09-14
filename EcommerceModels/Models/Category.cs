using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*
 * what to learn in this page??
Validations, Model Creation, Database schema (key), required for not null and html helpers for display orders 

 */

namespace EcommerceModels.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Name should be mandatory")]
        [DisplayName("Category Name")]
        [MaxLength(30,ErrorMessage ="Maximum Length of Category Name should be 30")]
        public String  Name{ get; set; }
        //for displaying in html by using html helper(html for)
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order should be between 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
