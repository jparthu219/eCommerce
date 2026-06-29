using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommaerce.Core.DTO
{
    public class RegisterRequest
    {
        [EmailAddress]
        [Required(ErrorMessage ="Email is Required")]
        public string Email {  get; set; }

        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage ="PersonName is Required")]
        public string PersonName {  get; set; }

        [Required(ErrorMessage ="Gender is Required")]
        public GenderOptions GenderOptions { get; set; }
    }
}
