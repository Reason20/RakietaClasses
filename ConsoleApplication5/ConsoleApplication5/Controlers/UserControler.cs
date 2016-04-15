using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Controlers
{
    class UserControler
    {
        public void addUser()
        {
            //using (var context = new Model1())
            //{
                //var umowa = new Contract()
                //{
                //    AgreementDate = DateTime.Now,
                //    From = DateTime.Now,
                //    To = new DateTime(2017, 12, 31),
                //    IsValid = true,
                //    Salary = 1500.50,
                //    Payday = 12,
                //    WorkingHours = 20,
                //    Type = TypesOfContract.KrótkoterminowaOPracę,
                //    WorkerId = 0,
                //    LastEditTime = DateTime.Now,
                //};
                //var pracownik = new WorkerSets()
                //{
                //    LastEditTime = DateTime.Now,
                //    UserSets1 = context.User.Find(1)
                //};
                //context.WorkerSets.Add(pracownik);
                //context.SaveChanges();
                //context.Contract.Add(umowa);
                //context.SaveChanges();
                //var user = context.User.Find(pracownik.Id);
                //if (user != null)
                //{
                //    user.WorkerId = pracownik.Id;
                //}
                //context.SaveChanges();
            //}
            using (var context = new Model1())
            {
                var skarbonka = new Moneybox()
                {
                    Value = "25,57",
                    NumberOfUsers = 4
                };
                var adres = new Address()
                {
                    Street = "Langiewicza",
                    HouseNumber = "2",
                    ApartmentNumber = "8",
                    PostalCode = "26-680",
                    City = "Poznań",
                    Province = Provinces.Mazowieckie,
                    Country = Countries.Poland
                };
                context.Address.Add(adres);
                context.Moneybox.Add(skarbonka);
                context.SaveChanges();
            }



        }

    }
}
