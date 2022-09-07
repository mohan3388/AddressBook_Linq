namespace AddressBook
{
    class Program
    {
        public static void Main(string[] args)
        {
            Book addressBook = new Book();
            addressBook.CreateTableUsingLinq();
        }
    }
}