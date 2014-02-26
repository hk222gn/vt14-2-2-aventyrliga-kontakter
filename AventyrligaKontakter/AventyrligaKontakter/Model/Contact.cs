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
        [RegularExpression("[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}", ErrorMessage = "Inmatningen matchar inte en Mail adress.")]
        [StringLength(50, ErrorMessage = "Fältets länd måste vara emellan 1 och 50 tecken.")] // Reg ex for mail
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Fältet måste vara ifyllt.")]
        [StringLength(50, ErrorMessage = "Fältets länd måste vara emellan 1 och 50 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fältet måste vara ifyllt.")]
        [StringLength(50, ErrorMessage = "Fältets länd måste vara emellan 1 och 50 tecken.")]
        public string LastName { get; set; }
    }
}