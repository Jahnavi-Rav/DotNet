using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceDemo.Model;

namespace WcfServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string DeleteEmployee(int employeeId)
        {
            string result = "Fail";
            try
            {
                DB_EmployeeEntities _context = new DB_EmployeeEntities();
                _context.Proc_tbl_Employee_Master_Update_Status(employeeId, false);
                result = "Success";
            }
            catch (Exception)
            {

            }
            return result;
        }

        public List<Employee_Master> GetEmployee()
        {
            List<Employee_Master> employeeList = new List<Employee_Master>();
            try
            {
                DB_EmployeeEntities _context = new DB_EmployeeEntities();
                var data = _context.tbl_Employee_Master.ToList();
                foreach(var item in data)
                {
                    Employee_Master emp = new Employee_Master();
                    emp.Employee_Id = item.Employee_Id;
                    emp.Employee_Name = item.Employee_Name;
                    emp.AddressLine1 = item.Address_Line1;
                    emp.AddressLine2 = item.Address_Line2;
                    emp.Contact_No = item.Contact_No;
                    emp.Email = item.Email;
                    emp.City = item.City;
                    emp.State = item.State;
                    emp.Country = item.Country;
                    emp.zipCode = item.Zip_Code;
                    employeeList.Add(emp);
                }
            }
            catch (Exception ex)
            {
                
            }
            return employeeList;
        }

        public Employee_Master GetEmployeeById(int employeeId)
        {
            Employee_Master emp = new Employee_Master();
            try
            {
                DB_EmployeeEntities _context = new DB_EmployeeEntities();
                var item = _context.tbl_Employee_Master.Find(employeeId);

                emp.Employee_Id = item.Employee_Id;
                emp.Employee_Name = item.Employee_Name;
                emp.AddressLine1 = item.Address_Line1;
                emp.AddressLine2 = item.Address_Line2;
                emp.Contact_No = item.Contact_No;
                emp.Email = item.Email;
                emp.City = item.City;
                emp.State = item.State;
                emp.Country = item.Country;
                emp.zipCode = item.Zip_Code; 
            }
            catch (Exception ex)
            {
            }
            return emp;
        }

        public string InsertEmployee(Employee_Master emp)
        {
            string result = "Fail";
            try
            {
                DB_EmployeeEntities _context = new DB_EmployeeEntities();
                _context.Proc_tbl_Employee_Master_Insert_Data(emp.Employee_Name, emp.Contact_No, emp.Email, emp.AddressLine1, emp.AddressLine2, emp.City, emp.State, emp.Country, emp.zipCode);
                result = "Success";            
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public string UpdateEmployee(Employee_Master emp)
        {
            string result = "Fail";
            try
            {
                DB_EmployeeEntities _context = new DB_EmployeeEntities();
                _context.Proc_tbl_Employee_Master_Update_Data(emp.Employee_Id, emp.Employee_Name, emp.Contact_No, emp.Email, emp.AddressLine1, emp.AddressLine2, emp.City, emp.State, emp.Country, emp.zipCode);
                result = "Success";
            }
            catch (Exception)
            {

            }
            return result;
        }

        string IService1.GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
