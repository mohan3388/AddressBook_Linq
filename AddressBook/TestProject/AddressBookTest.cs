using AddressBook;

namespace TestProject
{
    public class AddressBookTest
    {
        Book address = new Book();
        [SetUp]
        public void Setup()
        {
            address = new Book();
        }

        [Test]
        public void GivenInsertValues_returnInteger()
        {
            int expected = 2;
            int actual = address.AddDataInDatatable();
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void GivenModifyValues_returnInteger()
        {
            int expected = 0;
            int actual = address.EditInDataTable("Sahu", "Firstname");
            Assert.AreEqual(actual, expected);
        }
    }
}