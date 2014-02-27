using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AventyrligaKontakter.Model
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Mail fältet måste vara ifyllt.")]
        [RegularExpression("[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}", ErrorMessage = "Inmatningen matchar inte en Mail adress.")]
        [StringLength(50, ErrorMessage = "Fältets längd måste vara emellan 1 och 50 tecken.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Fältet måste vara ifyllt.")]
        [StringLength(50, ErrorMessage = "Fältets längd måste vara emellan 1 och 50 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fältet måste vara ifyllt.")]
        [StringLength(50, ErrorMessage = "Fältets längd måste vara emellan 1 och 50 tecken.")]
        public string LastName { get; set; }
    }
}