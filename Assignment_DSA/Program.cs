using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department root = new Department("root");
            fillWithData(root);
            string menu =
                "Please enter one of these commands to proceed:\n" +
                "1. Find and get Department.\n" +
                "2. Add new Subdepartment.\n" +
                "3. Delete current Department.\n" +
                "4. Move current Department to another as Subdepartment.\n" +
                "5. Add an employee to current Department.\n" +
                "6. Delete an employee from current Department\n" +
                "7. Move employee from current Department to another.\n" +
                "8. Display employees for this Departments and the ones under it.\n";
            ;

            Console.WriteLine(menu);
            displayCurrentDep(root);
            Console.WriteLine("");
            int input = int.Parse(Console.ReadLine());
            Department current = root;
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Please enter the desired Department you are looking for:");
                        string desiredDep = Console.ReadLine();
                        current = root;
                        current = current.FindDepartment(current, desiredDep);
                        if (current == null)
                        {
                            Console.WriteLine("Department does not exist. Press enter to continue.");
                            current = root;
                            Console.ReadLine();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please enter the new departments name:");
                        string desiredDepName = Console.ReadLine();
                        Department toAdd = new Department(desiredDepName);
                        current.AddDepartment(toAdd);
                        Console.WriteLine("Department successfully added! Press enter to continue.");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        if (current == root) 
                        {
                            Console.WriteLine("Cannot delete root department! Press enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            var tempParent = current.Parent;
                            current.DeleteDepartment();
                            current = tempParent;
                            Console.WriteLine("Department successfuly deleted. All subdepartments have been given to the Parent department.\n" +
                                "Returning to Parent department. Press enter to continue.");
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Please enter the department you want to move it to:");
                        string toDep = Console.ReadLine();
                        current.moveDepartment(toDep, root);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Please enter the new employees name:");
                        string empName = Console.ReadLine();
                        Employee emp = new Employee(empName);
                        current.addEmployee(empName);
                        Console.WriteLine("Employee successfuly added! Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        if (current.employees.Count == 0)
                        {
                            Console.WriteLine("No employees to delete! Press enter to continue.");
                            Console.ReadLine();
                            break;
                        }
                        Console.WriteLine("Please enter the name of the employee to delete:");
                        string empNameDel = Console.ReadLine();
                        current.deleteEmployee(empNameDel);
                        break;
                    case 7:
                        Console.Clear();
                        if (current.employees.Count == 0)
                        {
                            Console.WriteLine("There are no employees in this department to move. Press enter to continue.");
                            Console.ReadLine();
                            break; ;
                        }

                        Console.WriteLine("Please enter the name of the employee you want to move:\n");
                        Console.WriteLine("PS. Please write the employees name correctly, because there is no validation,\n" +
                            "it is 4 AM when I write this code\n" +
                            "and I am too tired to write more validation...");
                        string empMoveName = Console.ReadLine();
                        Console.WriteLine("\nTo which Department:");
                        Console.WriteLine("PS. Same goes here. I need some sleep because of my brilliant time management skills.\n" +
                            "Please share any advice you have for this problem that I have...");
                        string toWhichDepName = Console.ReadLine();
                        current.moveEmployee(empMoveName, toWhichDepName, root);
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine($"Number of total employees in current department and all subdepartments is: {current.calculateEmployees(current)}.");
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }

                Console.Clear();
                Console.WriteLine(menu + "\n");
                displayCurrentDep(current);
                Console.WriteLine("");
                input = int.Parse(Console.ReadLine());
            }
        }

        static void displayCurrentDep(Department dep)
        {
            Console.WriteLine($"You are currently managing {dep.depName} department.");
            if (dep.Parent != null)
            {
                Console.WriteLine($"The Parent department is: {dep.Parent.depName}.");
            }
            Console.WriteLine("\nActive subdepartments:");
            foreach (Department subDep in dep.subDepartments)
            {
                Console.WriteLine(subDep.depName);
            }
            Console.WriteLine("\nActive employees:");
            foreach (Employee emp in dep.employees)
            {
                Console.WriteLine(emp.fullName);
            }
        }

        static void fillWithData(Department root)
        {
            Department Engineering = new Department("Engineering");
            Department Accounting = new Department("Accounting");
            Department QA = new Department("QA");

            root.AddDepartment(Engineering);
            root.AddDepartment(Accounting);
            root.AddDepartment(QA);

            Department Software = new Department("Software");
            Department Mechanical = new Department("Mechanical");

            Engineering.AddDepartment(Software);
            Engineering.AddDepartment(Mechanical);

            Department Income = new Department("Income");
            Department Expenses = new Department("Expenses");

            Accounting.AddDepartment(Income);
            Accounting.AddDepartment(Expenses);

            Department ManualQA = new Department("ManualQA");
            Department AutoQA = new Department("AutoQA");

            QA.AddDepartment(ManualQA);
            QA.AddDepartment(AutoQA);

            Department BackEnd = new Department("BackEnd");
            Department FrontEnd = new Department("FrontEnd");
            
            Software.AddDepartment(FrontEnd);
            Software.AddDepartment(BackEnd);

            Department Hardware = new Department("Hardware");

            Mechanical.AddDepartment(Hardware);

            Department PythonQA = new Department("PythonQA");
            Department JavaQA = new Department("JavaQA");

            AutoQA.AddDepartment(PythonQA);
            AutoQA.AddDepartment(JavaQA);
        }
    }
}
