namespace ConsoleProject
{
    using ConsoleProject.Models;
    using ConsoleProject.Services;
    using System;

    class Program
    {
        static void Main()
        {
            
            var userService = new UserService();
            var user1 = new User("Farid Bandiyev", "bendiyevf@gmail.com", "Ferid2006043");
            userService.AddUser(user1);

            
            Console.WriteLine("Please login to proceed.");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            try
            {
                var loggedInUser = userService.Login(email, password);
                Console.WriteLine($"Welcome, {loggedInUser.Fullname}!");

                
                var categoryService = new CategoryService();
                var category1 = new Category("Pain Relief");
                categoryService.CreateCategory(category1);

                
                var medicineService = new MedicineService();
                var medicine1 = new Medicine("Paracetamol", 10.5m, category1.Id, loggedInUser.Id, "07.04.2024");
                var medicine2 = new Medicine("Ibuprofen", 5.5m, category1.Id, loggedInUser.Id, "07.04.2024");
                medicineService.CreateMedicine(medicine1);
                medicineService.CreateMedicine(medicine2);

                
                Console.WriteLine();
                Console.WriteLine("All Medicines:");
                var allMedicines = medicineService.GetAllMedicines();
                foreach (var medicine in allMedicines)
                {
                    Console.WriteLine($"{medicine.Id} - {medicine.Name} ({medicine.Price} AZN)");
                }

                
                Console.WriteLine();
                Console.WriteLine("Medicines in Pain Relief category:");
                var painReliefMedicines = medicineService.GetMedicineByCategory(category1.Id);
                foreach (var medicine in painReliefMedicines)
                {
                    Console.WriteLine($"{medicine.Id} - {medicine.Name}");
                }

                
                Console.WriteLine();
                Console.WriteLine("Removing a medicine...");
                var medicineToRemove = allMedicines[0];
                medicineService.RemoveMedicine(medicineToRemove.Id);
                Console.WriteLine($"Medicine '{medicineToRemove.Name}' removed.");

                
                Console.WriteLine();
                Console.WriteLine("All Medicines after removal:");
                allMedicines = medicineService.GetAllMedicines();
                foreach (var medicine in allMedicines)
                {
                    Console.WriteLine($"{medicine.Id} - {medicine.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
