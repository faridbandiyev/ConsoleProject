using ConsoleProject.Models;
using ConsoleProject.MyExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Services
{
    public class MedicineService
    {
        public void CreateMedicine(Medicine medicine)
        {
            var categoryExists = false;

            foreach (var category in DB.Categories)
            {
                if (category.Id == medicine.CategoryId)
                {
                    categoryExists = true;
                    break;
                }
            }

            if (!categoryExists)
            {
                throw new NotFoundException("Category not found");
            }

            Array.Resize(ref DB.Medicines, DB.Medicines.Length + 1);
            DB.Medicines[DB.Medicines.Length - 1] = medicine;
        }

        public Medicine[] GetAllMedicines()
        {
            return DB.Medicines;
        }

        public Medicine GetMedicineById(int id)
        {
            foreach (var medicine in DB.Medicines)
            {
                if (medicine.Id == id)
                {
                    return medicine;
                }
            }
            throw new NotFoundException("Medicine not found");
        }

        public Medicine GetMedicineByName(string name)
        {
            foreach (var medicine in DB.Medicines)
            {
                if (medicine.Name == name)
                {
                    return medicine;
                }
            }
            throw new NotFoundException("Medicine not found");
        }

        public Medicine[] GetMedicineByCategory(int categoryId)
        {
            int count = 0;

            foreach (var medicine in DB.Medicines)
            {
                if (medicine.CategoryId == categoryId)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                throw new NotFoundException("No medicines found in this category");
            }

            var medicinesInCategory = new Medicine[count];
            int index = 0;

            foreach (var medicine in DB.Medicines)
            {
                if (medicine.CategoryId == categoryId)
                {
                    medicinesInCategory[index] = medicine;
                    index++;
                }
            }

            return medicinesInCategory;
        }

        public void RemoveMedicine(int id)
        {
            var medicineIndex = -1;

            for (int i = 0; i < DB.Medicines.Length; i++)
            {
                if (DB.Medicines[i].Id == id)
                {
                    medicineIndex = i;
                    break;
                }
            }

            if (medicineIndex == -1)
            {
                throw new NotFoundException("Medicine not found");
            }

            for (int i = medicineIndex; i < DB.Medicines.Length - 1; i++)
            {
                DB.Medicines[i] = DB.Medicines[i + 1];
            }

            Array.Resize(ref DB.Medicines, DB.Medicines.Length - 1);
        }

        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            var medicineIndex = -1;

            for (int i = 0; i < DB.Medicines.Length; i++)
            {
                if (DB.Medicines[i].Id == id)
                {
                    medicineIndex = i;
                    break;
                }
            }

            if (medicineIndex == -1)
            {
                throw new NotFoundException("Medicine not found");
            }

            DB.Medicines[medicineIndex] = updatedMedicine;
        }
    }
}
