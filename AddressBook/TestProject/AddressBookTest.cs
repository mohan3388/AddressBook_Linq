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
        [Test]
        public void GivenDeleteQuery_returnInteger()
        {
            int expected = 1;
            int actual = address.DeleteRowInDataTable("Kshma");
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void GivenRetrieveQuery_BasedOnCityandState_returnString()
        {
            string expected = "Mohan Sahu";
            string actual = address.RetrieveBasedOnCityorState("Bhilai", "CG");
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GivenRetrieveCount_BasedOnCityandState_returnString()
        {
            string expected = "1 1 ";
            string actual = address.RetrieveCountBasedOnCityorState();
            Assert.AreEqual(expected, actual);
        }

    }
}