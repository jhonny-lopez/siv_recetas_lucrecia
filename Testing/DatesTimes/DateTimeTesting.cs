using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Domain.Contacts;

namespace Testing.DatesTimes
{
    static class DateTimeTesting
    {
        static void Testing()
        {
            DateTime now = DateTime.Now;

            Console.WriteLine(now);
            Console.WriteLine("Día del mes: " + now.Day);
            Console.WriteLine("Mes: " + now.Month);
            Console.WriteLine("Día de la semana: " + now.DayOfWeek);
            Console.WriteLine("Día del año: " + now.DayOfYear);
            Console.WriteLine("Hora local convertida a hora universal: " + now.ToUniversalTime());

            Console.WriteLine("El año es bisiesto? " + DateTime.IsLeapYear(2024));

            Console.WriteLine("La fecha solamente es: " + now.Date);

            var hour = now.TimeOfDay;

            var firstDayOfMonth = new DateTime(DateTime.Now.Year, 1, 1);

            var timeSpan = now - firstDayOfMonth;

            Console.WriteLine(now.ToString("dddd dd/MM/yyyy hh:mm tt"));

            var otherTimeSpan = now + new TimeSpan(5, 3, 20, 0);

            var ots = now.AddDays(5).AddHours(3).AddMinutes(20);

            Console.WriteLine($"Han pasado {(int)timeSpan.TotalDays} días, {(int)timeSpan.Hours} horas, {timeSpan.Minutes} minutos y {timeSpan.Seconds} segundos desde {firstDayOfMonth}");

            Console.WriteLine("El resultado de sumar fue: " + otherTimeSpan);

            Console.WriteLine("Primer día del mes es: " + firstDayOfMonth);

            Console.WriteLine("La hora es: " + hour);

            now = now.AddDays(5);

            Console.WriteLine(now);

            Console.ReadKey();
        }

        private static void NullValidations()
        {
            string myString = null;
            TestNullConditionalOperator();

            Contact contact = InitializeContact(true, true);

            string helloWorld = null;

            Console.WriteLine($"{helloWorld!}");

            Console.WriteLine($"El contacto {contact!.FullName} vive en {contact!.City!.Name}");

            int myOtherBalance = TestNullOperators();

            Console.WriteLine("My other balance " + myOtherBalance);

            Console.WriteLine(myString.RemoveAllWhiteSpaces());

            TestExtensionsMethods();
        }

        private static void TestNullConditionalOperator()
        {
            Contact contact = InitializeContact(false, false);

            Console.WriteLine($"El contacto {contact?.FullName} vive en la ciudad: {contact?.City?.Name}");
        }

        private static int TestNullOperators()
        {
            //Convertir un tipo valor a nullable
            int? balance = CalculateBalance();

            //Comparar una variable con null
            if (balance is null)
            {
                balance = 0;
            }

            //Operador Null Coalescence con asignación
            balance ??= 0;

            //Operador Null Coalescense 
            int myOtherBalance = balance ?? 0;
            return myOtherBalance;
        }

        private static int? CalculateBalance()
        {
            return null;
        }

        private static Contact InitializeContact(bool initializeCity, bool initializeContact)
        {
            if (initializeContact)
            {

                var contact = new Contact
                {
                    CityId = 1,
                    ContactBy = ContactMethods.Email,
                    EmailAddress = "juanperez@google.com",
                    FullName = "Juan Pérez",
                    PhoneNumber = "315565654654",
                    Id = Guid.NewGuid()
                };

                if (initializeCity)
                {
                    contact.City = new Domain.Regions.City()
                    {
                        Id = 1,
                        Name = "Cali"
                    };
                }

                return contact;
            }
            else
            {
                return null;
            }
        }

        private static void TestExtensionsMethods()
        {
            string myString = "42,5";

            int myInt = myString.ToInt(defaultValue: -1);
            double myDouble = myString.ToDouble();

            string helloWorld = "Hola mundo del software".RemoveAllWhiteSpaces();

            Console.WriteLine(helloWorld);

            Console.WriteLine(myInt);
            Console.WriteLine(myDouble);
        }
    }
}
