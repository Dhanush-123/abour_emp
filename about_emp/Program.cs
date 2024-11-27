using System;

namespace CompanyHierarchy
{
    // Abstract Base Class (Abstraction)
    public abstract class Employee
    {
        // Properties (Encapsulation)
        public string Name { get; set; }
        public int Id { get; set; }

        // Constructor
        protected Employee(string name, int id)
        {
            Name = name;
            Id = id;
        }

        // Abstract method to calculate salary (Abstraction)
        public abstract decimal CalculateSalary();

        // Virtual method for displaying employee details
        public virtual void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Employee ID: {Id}, Name: {Name}");
        }
    }

    // Derived Class: FullTimeEmployee (Inheritance)
    public class FullTimeEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }

        // Constructor
        public FullTimeEmployee(string name, int id, decimal monthlySalary)
            : base(name, id)
        {
            MonthlySalary = monthlySalary;
        }

        // Override method to calculate salary (Polymorphism)
        public override decimal CalculateSalary()
        {
            return MonthlySalary;
        }

        // Override method for displaying full-time employee details
        public override void DisplayEmployeeInfo()
        {
            base.DisplayEmployeeInfo();
            Console.WriteLine($"Position: Full-Time, Monthly Salary: {MonthlySalary:C}");
        }
    }

    // Derived Class: PartTimeEmployee (Inheritance)
    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        // Constructor
        public PartTimeEmployee(string name, int id, decimal hourlyRate, int hoursWorked)
            : base(name, id)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        // Override method to calculate salary (Polymorphism)
        public override decimal CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }

        // Override method for displaying part-time employee details
        public override void DisplayEmployeeInfo()
        {
            base.DisplayEmployeeInfo();
            Console.WriteLine($"Position: Part-Time, Hourly Rate: {HourlyRate:C}, Hours Worked: {HoursWorked}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Creating objects of derived classes (Polymorphism)
            Employee fullTimeEmployee = new FullTimeEmployee("Alice", 101, 3000m);
            Employee partTimeEmployee = new PartTimeEmployee("Bob", 102, 20m, 80);

            // Array of Employee objects (demonstrating Polymorphism)
            Employee[] employees = { fullTimeEmployee, partTimeEmployee };

            foreach (Employee emp in employees)
            {
                emp.DisplayEmployeeInfo();
                Console.WriteLine($"Calculated Salary: {emp.CalculateSalary():C}\n");
            }
        }
    }
}
