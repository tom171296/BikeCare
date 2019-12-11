using System;

namespace BikeManagementAPITests.Support.Context
{
    public class UserContext
    {
        public string EmployeeNumber { get; set; }
        public bool Authorized { get; set; } = false;
    }
}