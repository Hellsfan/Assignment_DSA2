using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_DSA
{
    internal class Department
    {
        public string depName { get; set; }
        public string ManagerName { get; set; }
        public Department Parent { get; set; }
        public List<Employee> employees { get; set; }
        public List<Department> subDepartments { get; set; }

        public Department(string depName)
        {
            this.depName = depName;
            employees = new List<Employee>();
            subDepartments = new List<Department>();
        }
        #region department management
        public Department FindDepartment(Department root, string name)
        {
            if (root.depName.Equals(name)) return root;
            if (root.subDepartments.Count == 0) return null;
            foreach (Department department in root.subDepartments)
            {
                if (department.depName.Equals(name)) return department;
                var temp = FindDepartment(department, name);
                if (temp != null) return temp;
            }
            return null;
        }

        public void AddDepartment(Department dep)
        {
            dep.Parent = this;
            this.subDepartments.Add(dep);
        }

        public void DeleteDepartment()
        {
            Department save = this;
            foreach (Department department in save.subDepartments)
            {
                Parent.AddDepartment(department);
            }
            Parent.subDepartments.Remove(save);
        }

        public void moveDepartment(string toDepartment, Department root)
        {
            var tempDep = this;
            if (tempDep.depName.Equals(root.depName))
            {
                Console.WriteLine("Cannot move root department! Press enter to continue.");
                Console.ReadLine();
                return;
            }

            var toDep = FindDepartment(root, toDepartment);
            if (toDep == null)
            {
                Console.WriteLine("Desired department does not exist! Press enter to continue.");
                Console.ReadLine();
                return;
            };

            this.Parent.subDepartments.Remove(this);
            tempDep.Parent = toDep;
            toDep.subDepartments.Add(tempDep);
        }

        public int calculateEmployees(Department department)
        {
            if (department.subDepartments.Count == 0) return department.employees.Count;
            int total = department.employees.Count;
            foreach (Department dep in department.subDepartments)
            {
                total = total + calculateEmployees(dep);
            }
            return total;
        }
        #endregion

        #region employees management
        public void addEmployee(string name)
        {
            Employee employee = new Employee(name);
            employees.Add(employee);
        }
        public void deleteEmployee(string name)
        {
            foreach (var employee in employees)
            {
                if (employee.fullName.Equals(name))
                {
                    employees.Remove(employee);
                    Console.WriteLine("Employee successfuly found and deleted! Press enter to continue");
                    Console.ReadLine();
                    return;
                }
            }

            Console.WriteLine("Desired employee does not exist in this department! Press enter to continue");
            Console.ReadLine();
        }
        public void moveEmployee(string employeeName, string toDep, Department root)
        {
            Employee transit;
            Department toDepartment = FindDepartment(root, toDep);

            foreach (var employee in employees)
            {
                if (employee.fullName.Equals(employeeName))
                {
                    transit = new Employee(employeeName);
                    toDepartment.employees.Add(transit);
                    this.deleteEmployee(transit.fullName);
                    Console.WriteLine("Please ignore the previous message, it is a bug. Thank you. Press enter to continue");
                    Console.ReadLine();
                    return;
                }

            }
        }
        #endregion
    }
}
