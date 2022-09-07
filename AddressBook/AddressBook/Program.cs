namespace AddressBook
{
    class Program
    {
        public static void Main(string[] args)
        {
            Book addressBook = new Book();
            Contact contact1 = new Contact();

            addressBook.CreateTableUsingLinq();
            contact1.Id = 1;
            contact1.FirstName = "Mohan";
            contact1.LastName = "Sahu";
            contact1.PhoneNumber = 7898524871;
            contact1.Email = "mohan54@gmail.com";
            contact1.Address = "katulboard";
            contact1.City = "Bhilai";
            contact1.State = "CG";
            contact1.zip = 490020;
            addressBook.InsertionInDataTable(contact1);



            addressBook.Display();
        }
    }
}