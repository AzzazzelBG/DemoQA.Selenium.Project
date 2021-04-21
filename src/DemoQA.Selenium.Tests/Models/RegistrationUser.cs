using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQA.Selenium.Tests.Models
{
    public class RegistrationUser
    {
        public RegistrationUser(
                                string firstName,
                                string lastName,
                                string email,
                                int genderIndex,
                                string phoneNumber,
                                string dateOfBirth,
                                string currentAddres)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            GenderIndex = genderIndex;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            CurrentAddres = currentAddres;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int GenderIndex { get; set; }

        public string PhoneNumber { get; set; }

        public string DateOfBirth { get; set; }

        public string CurrentAddres { get; set; }
    }
}
