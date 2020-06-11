using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAddressBook.Models
{
    class AddressPageModel
    {
        public string firstName { get; set; } = "Jon";

        public string lastName { get; set; } = "smith";

        public string address1 { get; set; } = "NY";

        public string address2 { get; set; } = "NJ";

        public string city { get; set; } = "NJ";

        public string state { get; set; } = "P";

        public string zipCode { get; set; } = "05963";

        public string age { get; set; } = "20";

        public string website { get; set; } = "www.google.com";

        public string phone { get; set; } = "147258369";

        public string note { get; set; } = "Note";

        public bool climbing = true;
        public bool dancing = true;
        public bool reading = true;
        public bool countryUS = true;
        public bool countryCanada = false;


        public AddressPageModel()
        {

        }

        /// <summary>
        /// function for creating a model of data. 
        /// </summary>
        /// <param name="Data">key = name of the data and value = its value.</param>
        public void CreateData(Dictionary<string, string> Data)
        {
            Dictionary<string, string> newData = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in Data)
            {
                switch (item.Key.ToLower())
                {
                    case "firstname":
                        firstName = item.Value;
                        break;
                    case "lastname":
                        lastName = item.Value;
                        break;
                    case "address1":
                        address1 = item.Value;
                        break;
                    case "address2":
                        address2 = item.Value;
                        break;
                    case "city":
                        city = item.Value;
                        break;
                    case "state":
                        state = item.Value;
                        break;
                    case "zipcode":
                        zipCode = item.Value;
                        break;
                    case "age":
                        age = item.Value;
                        break;
                    case "website":
                        website = item.Value;
                        break;
                    case "phone":
                        phone = item.Value;
                        break;
                    case "note":
                        note = item.Value;
                        break;
                    case "climbing":
                        climbing = true;
                        break;
                    case "dancing":
                        dancing = true;
                        break;
                    case "reading":
                        reading = true;
                        break;
                    case "countryUS":
                        countryUS = true;
                        break;
                    case "countryCanada":
                        countryCanada = true;
                        break;
                    default:
                        break;
                }

            }
        }

        public void clearModel()
        {
            firstName = "";
            lastName = "";
            address1 = "";
            address2 = "";
            city = "";
            state = "";
            zipCode = "";
            //country = "";
            age = "";
            website = "";
            phone = "";
            note = "";

            climbing = false;
            dancing = false;
            reading = false;
            countryUS = false;
            countryCanada = false;

        }
    }
}
