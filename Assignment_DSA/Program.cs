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
            Employee manager = new Employee("Da");
            Department root = new Department("Brazzers");
            string menu = "1. find dep.    2.add dep.  3.delete dep.   4. move dep. 5.display dep. 6.add employee 7.delete emp 8.move emp.";

            Console.WriteLine(menu);
            int input = int.Parse(Console.ReadLine());
            Department current = root;
            while (input != 0)
            {
                Console.Clear();
                Console.WriteLine(menu);
                
                switch (input)
                {
                    case 1:
                        string desiredDep = Console.ReadLine();
                        current = root;
                        current = current.FindDepartment(current, desiredDep);
                        if (current == null)
                        {
                            Console.WriteLine("Department does not exist");
                            current = root;
                        }
                        break;

                    case 2:
                        string desiredDepName = Console.ReadLine();
                        Department toAdd = new Department(desiredDepName);
                        current.AddDepartment(toAdd);
                        Console.WriteLine("added <3");
                        break;

                    case 3:
                        var tempParent = current.Parent;
                        current.DeleteDepartment();
                        current = tempParent;
                        Console.WriteLine("Department successfuly deleted. Returning to parent Department.");
                        break;
                    case 4:
                        Console.WriteLine("To where?");
                        string toDep=Console.ReadLine();
                        current.moveDepartment(toDep, root);
                        break;
                    case 5:
                        foreach (Department dep in current.subDepartments)
                        {
                            Console.WriteLine(dep.depName);
                        }
                        Console.ReadLine();
                        break;
                    case 6:
                        string empName = Console.ReadLine();
                        Employee emp = new Employee(empName);
                        current.addEmployee(empName);
                        break;
                    case 7:
                        string empNameDel = Console.ReadLine();
                        current.deleteEmployee(empNameDel);
                        break;
                    case 8:
                        Console.WriteLine("emp name pls:");
                        string empMoveName=Console.ReadLine();
                        Console.WriteLine("to which dep:");
                        string toWhichDepName=Console.ReadLine();
                        current.moveEmployee(empMoveName,toWhichDepName,root);
                        break;
                }
                Console.WriteLine($"Currently in: {current.depName}");
                foreach (Department dep in current.subDepartments)
                {
                    Console.WriteLine($"{dep.depName}");
                }
                Console.WriteLine("emps:");
                foreach(Employee emp in current.employees)
                {
                    Console.WriteLine($"{emp.fullName}");
                }
                input = int.Parse(Console.ReadLine());
            }


        }
    }
}
