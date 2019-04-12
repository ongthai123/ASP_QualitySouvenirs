using System.Linq;
using System;
using QuanlitySouvenir.Models;

namespace QuanlitySouvenir.Data
{
    public static class SouvenirDbInitializer
    {
        public static void Initialize(SouvenirshopContext context)
        {
            context.Database.EnsureCreated();
            //Look for any souvenir.
            //if (context.Souvenirs.Any())//Some issue
            //{
            //    Console.WriteLine("found souvenirs record: true");
            //   // DB has been seeded
            //}
            //else {
                var souvenirs = new Souvenir[]
                {
                new Souvenir{Name="SouvenirA",Price=15.00f,Description="I am descriptionA",Image="I am image url",SupplierID=123,CategoryID=101},
                new Souvenir{Name="SouvenirB",Price=25.00f,Description="I am descriptionB",Image="I am image url",SupplierID=223,CategoryID=101},
                new Souvenir{Name="SouvenirC",Price=35.00f,Description="I am descriptionC",Image="I am image url",SupplierID=123,CategoryID=102},
                new Souvenir{Name="SouvenirD",Price=45.00f,Description="I am descriptionD",Image="I am image url",SupplierID=323,CategoryID=102},
                new Souvenir{Name="SouvenirE",Price=55.00f,Description="I am descriptionE",Image="I am image url",SupplierID=123,CategoryID=103},
                new Souvenir{Name="SouvenirF",Price=65.00f,Description="I am descriptionF",Image="I am image url",SupplierID=223,CategoryID=103},
                new Souvenir{Name="SouvenirG",Price=75.00f,Description="I am descriptionG",Image="I am image url",SupplierID=123,CategoryID=104},
                new Souvenir{Name="SouvenirH",Price=85.00f,Description="I am descriptionH",Image="I am image url",SupplierID=323,CategoryID=105},
                new Souvenir{Name="SouvenirA1",Price=15.00f,Description="I am descriptionA1",Image="I am image url",SupplierID=123,CategoryID=101},
                new Souvenir{Name="SouvenirB1",Price=25.00f,Description="I am descriptionB1",Image="I am image url",SupplierID=223,CategoryID=101},
                new Souvenir{Name="SouvenirC1",Price=35.00f,Description="I am descriptionC1",Image="I am image url",SupplierID=123,CategoryID=102},
                new Souvenir{Name="SouvenirD1",Price=45.00f,Description="I am descriptionD1",Image="I am image url",SupplierID=323,CategoryID=102},
                new Souvenir{Name="SouvenirE1",Price=55.00f,Description="I am descriptionE1",Image="I am image url",SupplierID=123,CategoryID=103},
                new Souvenir{Name="SouvenirF1",Price=65.00f,Description="I am descriptionF1",Image="I am image url",SupplierID=223,CategoryID=103},
                new Souvenir{Name="SouvenirG1",Price=75.00f,Description="I am descriptionG1",Image="I am image url",SupplierID=123,CategoryID=104},
                new Souvenir{Name="SouvenirH1",Price=85.00f,Description="I am descriptionH1",Image="I am image url",SupplierID=323,CategoryID=105},
                new Souvenir{Name="SouvenirA2",Price=15.00f,Description="I am descriptionA2",Image="I am image url",SupplierID=123,CategoryID=101},
                new Souvenir{Name="SouvenirB2",Price=25.00f,Description="I am descriptionB2",Image="I am image url",SupplierID=223,CategoryID=101},
                new Souvenir{Name="SouvenirC2",Price=35.00f,Description="I am descriptionC2",Image="I am image url",SupplierID=123,CategoryID=102},
                new Souvenir{Name="SouvenirD2",Price=45.00f,Description="I am descriptionD2",Image="I am image url",SupplierID=323,CategoryID=102},
                new Souvenir{Name="SouvenirE2",Price=55.00f,Description="I am descriptionE2",Image="I am image url",SupplierID=123,CategoryID=103},
                new Souvenir{Name="SouvenirF2",Price=65.00f,Description="I am descriptionF2",Image="I am image url",SupplierID=223,CategoryID=103},
                new Souvenir{Name="SouvenirG2",Price=75.00f,Description="I am descriptionG2",Image="I am image url",SupplierID=123,CategoryID=104},
                new Souvenir{Name="SouvenirH2",Price=85.00f,Description="I am descriptionH2",Image="I am image url",SupplierID=323,CategoryID=105},
                };
                foreach (Souvenir s in souvenirs)
                {
                    context.Souvenirs.Add(s);
                }
                context.SaveChanges();


            //if (context.Customers.Any())//Some issue
            //{
            //    Console.WriteLine("found customers record: true");
            //    // DB has been seeded
            //}
            //else
            //{
                    var customers = new Customer[]
               {
                    new Customer{Name="Pieter Chen",PhoneNumber="123-44561",EmailAddress="Pieter@kkk",Address="address01",Enabled=true},
                    new Customer{Name="Jason K",PhoneNumber="123-44562",EmailAddress="Jason@kk",Address="address02",Enabled=true},
                    new Customer{Name="Kobe A",PhoneNumber="123-44563",EmailAddress="Kobe@kk",Address="address03",Enabled=true},
                    new Customer{Name="Paul C",PhoneNumber="123-44564",EmailAddress="Paul@kk",Address="address04",Enabled=true},
                    new Customer{Name="Amanda Chong",PhoneNumber="123-44565",EmailAddress="Amanda@kk",Address="address05",Enabled=true},
                    new Customer{Name="Andson K",PhoneNumber="123-44566",EmailAddress="Andson@kk",Address="address06",Enabled=true},
                    new Customer{Name="Wooden J",PhoneNumber="123-44567",EmailAddress="Wooden@kk",Address="address07",Enabled=true},
                    new Customer{Name="Luoyis M",PhoneNumber="123-44568",EmailAddress="Luoyis@kk",Address="address08",Enabled=true},
               };
                    foreach (Customer c in customers)
                    {
                        context.Customers.Add(c);
                    }
                    context.SaveChanges();

            //if (context.Suppliers.Any())//Some issue
            //{
            //    Console.WriteLine("found Suppliers record: true");
            //    // DB has been seeded
            //}
            //else
            //{
                var suppliers = new Supplier[]
            {
                new Supplier{SupplierID=123,Name="ABC Company",PhoneNumber="1001010101",EmailAddress="ABC@xxx.com"},
                new Supplier{SupplierID=223,Name="BBC Company",PhoneNumber="1001010102",EmailAddress="BBC@xxx.com"},
                new Supplier{SupplierID=323,Name="CBC Company",PhoneNumber="1001010103",EmailAddress="CBC@xxx.com"}

            };
                foreach (Supplier e in suppliers)
                {
                    context.Suppliers.Add(e);
                }
                context.SaveChanges();



        }
    }
}
