using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Message
{
    public static class MessageText
    {
        public static string SuccessMessage = "Success Message";
        public static string ErrorMessage = "Error Message";
        public static string ReturnRentalError = "The car has not yet been delivered.";
        public static string CarImageCountLimitError = "Car image count cannot be more 5";
        public static string EmailNotFound = "Email not found";

        public static string UserNotFound = "User not found";

        public static string PasswordError = "User password not correct";
        public static string SuccessfulLogin = "User does login successfully";
        public static string AccessTokenCreated = "Token created successfully";
        public static string UserRegistered = "User registered successfully";
        public static string UserAlreadyExists = "User Already Exists";
    }
}
