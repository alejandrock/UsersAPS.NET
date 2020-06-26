using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Users.Areas.User.Pages.Account
{
    public class RegisterModel : PageModel
    {

        private UserManager<IdentityUser> _userManager;

        public RegisterModel(UserManager<IdentityUser> userManager) {

            _userManager = userManager;
        
        }

        public void OnGet() {

        }
        public async Task<IActionResult> OnPostAsync() {


            if (ModelState.IsValid)
            {
                var userList = _userManager.Users.Where(u => u.Email.Equals(Input.Email)).ToList();
                if (userList.Count.Equals(0)) {

                    IdentityUser user = new IdentityUser { 
                        UserName = Input.Email,
                        Email = Input.Email
                    };
                    var result = await _userManager.CreateAsync( user, Input.Password);
                    
                    if (result.Succeeded) {

                        return Page();

                    }
                    else
                    {
                        foreach (var item in result.Errors) {

                            Input = new InputModel { ErrorMessage = item.Description, };
                        }
                        return Page();
                    }
                }
                else{
                    Input = new InputModel { ErrorMessage = $"El {Input.Email} ya esta registrado", };

                }

            }
            //else {

            //    ModelState.AddModelError("Input.Email", "Se ha generado un error en el servidor");  
            //}

            var data = Input;

            return Page();
        }

        [BindProperty]
        public InputModel Input {get; set; }  
            public class InputModel { 
            
            [Required(ErrorMessage ="The E-mail, is required")]
            [EmailAddress]
            [Display(Name="Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The Password, is required")]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")] 
            [StringLength(100, ErrorMessage ="El número de caracteres de {0} debe ser al menos {2},", MinimumLength = 6)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and comfirmation password do not match")]
            public String ConfirmPassword { get; set; }  

            //[Required]
            public string ErrorMessage { get; set; } 
            
        }
    }
}
