using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant //: IValidatableObject Custom Validations
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
