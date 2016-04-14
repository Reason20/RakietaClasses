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
            //var address = new Address()
            //{
            //    Street = "Langowskiego",
            //    HouseNumber = "1",
            //    ApartmentNumber = "2",
            //    PostalCode = "00-000",
            //    City = "Posen",
            //    Province = Provinces.Wielkopolskie,
            //    Country = Countries.Poland,
            //    LastEditTime = DateTime.Now
            //};

            //var money = new Moneybox()
            //{
            //    Value = "0",
            //    NumberOfUsers = 2
            //};


            //using (var context = new Model1())
            //{
            //    context.Address.Add(address);
            //    context.Moneybox.Add(money);
            //    context.SaveChanges();
            //}


            //using (var context = new Model1())
            //{
            //    var useraddress = context.Address.Where(e => e.Street == "Langowskiego" && e.HouseNumber == "1" && e.ApartmentNumber == "2");
            //    var addressid = useraddress.First().Id;


            //    User jan = new User()
            //    {
            //        FirstName = "jan",
            //        Login = "jan",
            //        Password = "passwd",
            //        Surname = "kowalski",
            //        PESEL = 1234568790,
            //        DateOfBirth = new DateTime(1993, 3, 03),
            //        Sex = MaleFemale.Mężczyzna,
            //        PlaceOfBirth = "kOlOBrzeG",
            //        IDNumber = "AWM877720",
            //        MainAddress = addressid,
            //        JoinDate = DateTime.Now,
            //        MoneyboxId = 1,
            //        LastEditTime = DateTime.Now

            //    };




            //    context.User.Add(jan);
            //    context.SaveChanges();

            //}
            using (var context = new Model1())
            {
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
            }



        }

    }
}
