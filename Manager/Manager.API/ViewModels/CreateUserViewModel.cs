using System;
using System.ComponentModel.DataAnnotations;


namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        
        
        [Required(ErrorMessage = "Name cannot be empty")]
        [MinLength(3, ErrorMessage = "The name must al least 3 characters.")]
        [MaxLength(100, ErrorMessage = "The name must have a maximum of 100 characters.")]
        public string Name {get;set;}


        [Required(ErrorMessage = "Email cannot be empty")]
        [MinLength(6, ErrorMessage = "The email must al least 6 characters.")]
        [MaxLength(180, ErrorMessage = "The email must have a maximum of 180 characters.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "The email informed is not valid")]
        public string Email {get;set;}

        [Required(ErrorMessage = "Password cannot be empty.")]
        [MinLength(10, ErrorMessage = "The password must al least 6 characterers.")]
        [MaxLength(80, ErrorMessage = "The password must have a maximum of 80 characteres.")]
        public string Password {get;set;}

    }
}