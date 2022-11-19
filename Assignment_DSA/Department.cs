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
        public Employee Manager { get; set; }
        public Department Parent { get; set; }
        public List<Employee> employees { get; set; }
        public List<Department> subDepartments { get; set; }

        public Department(string depName)
        {
            this.depName = depName;
            employees = new List<Employee>();
            subDepartments = new List<Department>();
        }

        public Department FindDepartment(Department tree, string name)
        {
            if (tree.depName.Equals(name)) return tree;
            if (tree.subDepartments.Count == 0) return null;
            foreach (Department department in tree.subDepartments)
            {
                if (department.depName == name) return department;
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
            if (this.depName == "Brazzers")
            {
                Console.WriteLine("Cannot delete root.");
            }
            else
            {
                Department save = this;
                foreach (Department department in save.subDepartments)
                {
                    Parent.AddDepartment(department);
                }
                Parent.subDepartments.Remove(save);
            }
        }

        public void moveDepartment(string toDepartment, Department root)
        {

            var tempDep = this;
            if (tempDep.depName.Equals(toDepartment))
            {
                Console.WriteLine("cannot move root department");
                return;
            }

            var toDep = FindDepartment(root, toDepartment);

            this.Parent.subDepartments.Remove(tempDep);
            toDep.subDepartments.Add(tempDep);

        }

        #region employees management
        public void addEmployee(string name)
        {
            Employee employee = new Employee(name);
            employees.Add(employee);
        }
        public void deleteEmployee(string name)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to delete!");
                return;
            }

            foreach (var employee in employees)
            {
                if (employee.fullName.Equals(name))
                {
                    employees.Remove(employee);
                    return;
                }
            }
        }
        public void moveEmployee(string employeeName, string toDep, Department root)
        {
            foreach (var employee in employees)
            {
                Employee transit;
                Department toDepartment = FindDepartment(root, toDep);

                if (employees.Count == 0)
                {
                    Console.WriteLine("There are no employees in this department to move");
                    return;
                }

                if (employee.fullName.Equals(employeeName))
                {
                    transit = new Employee(employeeName);
                    toDepartment.employees.Add(transit);
                    this.employees.Remove(transit);
                }

            }
        }
        #endregion
    }
}
