namespace Mysolution_Data.Migrations
{
    using CsvHelper;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Mysolution_Data.Context>
    {
      
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mysolution_Data.Context context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Mysolution_Data.Files.listofcountries.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    csvReader.Configuration.Delimiter = ";";
                    var countries = csvReader.GetRecords<country>().ToArray();
                    context.country.AddOrUpdate(c => c.IdCountry, countries);
                }
            }
            //resourceName = "Mysolution_Data.Files.export.csv";
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.Delimiter = ";";
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        while (csvReader.Read())
            //        {
            //            var myexport = csvReader.GetRecord<export>();
            //            var countryCode = csvReader.GetField<int>("country_IdCountry");
            //            myexport.country = context.country.Local.Single(c => c.IdCountry == countryCode);
            //            context.export.AddOrUpdate(p => p.Year, myexport);

            //        }
            //    }
            //}
            resourceName = "Mysolution_Data.Files.gdp.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.Delimiter = ";";
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    while (csvReader.Read())
                    {
                        var myexport = csvReader.GetRecord<gdp>();
                        var countryCode = csvReader.GetField<int>("country_IdCountry");
                        myexport.country = context.country.Local.Single(c => c.IdCountry == countryCode);
                        context.gdp.AddOrUpdate(p=>p.Year,myexport);
                    }
                }
            }
            //resourceName = "Mysolution_Data.Files.gdpgrowth.csv";
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.Delimiter = ";";
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        while (csvReader.Read())
            //        {
            //            var mygdpgrowth = csvReader.GetRecord<gdpgrowth>();
            //            var countryCode = csvReader.GetField<int>("country_IdCountry");
            //            mygdpgrowth.country = context.country.Local.Single(c => c.IdCountry == countryCode);
            //            context.gdpgrowth.AddOrUpdate(mygdpgrowth);
            //        }
            //    }
            //}
            //resourceName = "Mysolution_Data.Files.import.csv";
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.Delimiter = ";";
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        while (csvReader.Read())
            //        {
            //            var myimport = csvReader.GetRecord<import1>();
            //            var countryCode = csvReader.GetField<int>("country_IdCountry");
            //            myimport.country = context.country.Local.Single(c => c.IdCountry == countryCode);
            //            context.import1.AddOrUpdate(myimport);
            //        }
            //    }
            //}
            //resourceName = "Mysolution_Data.Files.inflation.csv";
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.Delimiter = ";";
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        while (csvReader.Read())
            //        {
            //            var myinflation = csvReader.GetRecord<inflation>();
            //            var countryCode = csvReader.GetField<int>("country_IdCountry");
            //            myinflation.country = context.country.Local.Single(c => c.IdCountry == countryCode);
            //            context.inflation.AddOrUpdate(myinflation);
            //        }
            //    }
            //}
            //resourceName = "Mysolution_Data.Files.natdebt.csv";
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.Delimiter = ";";
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        while (csvReader.Read())
            //        {
            //            var mynatdebt = csvReader.GetRecord<national_debt>();
            //            var countryCode = csvReader.GetField<int>("country_IdCountry");
            //            mynatdebt.country = context.country.Local.Single(c => c.IdCountry == countryCode);
            //            context.national_debt.AddOrUpdate(mynatdebt);
            //        }
            //    }
            //}
            //resourceName = "Mysolution_Data.Files.population.csv";
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.Delimiter = ";";
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        while (csvReader.Read())
            //        {
            //            var mypopulation = csvReader.GetRecord<population>();
            //            var countryCode = csvReader.GetField<int>("country_IdCountry");
            //            mypopulation.country = context.country.Local.Single(c => c.IdCountry == countryCode);
            //            context.population.AddOrUpdate(mypopulation);
            //        }
            //    }
            //}
            //resourceName = "Mysolution_Data.Files.unemployment.csv";
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.Delimiter = ";";
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        while (csvReader.Read())
            //        {
            //            var myunemployment = csvReader.GetRecord<unemployment>();
            //            var countryCode = csvReader.GetField<int>("country_IdCountry");
            //            myunemployment.country = context.country.Local.Single(c => c.IdCountry == countryCode);
            //            context.unemployment.AddOrUpdate(myunemployment);
            //        }
            //    }
            //}
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            //  context.People.AddOrUpdate(
            //    p => p.FullName,
            //    new Person { FullName = "Andrew Peters" },
            //    new Person { FullName = "Brice Lambson" },
            //    new Person { FullName = "Rowan Miller" }
            //  );

        }
    }
}
