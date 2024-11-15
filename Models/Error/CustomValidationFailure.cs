﻿namespace Digital_Account_Web_Api.Models.Error
{
    public class CustomValidationFailure
    {
        public CustomValidationFailure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
