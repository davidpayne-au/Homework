// Import the Xunit namespace for testing
using Xunit;

// Import the MaryLib namespace to access classes in the main project
using MaryLib;

// Declare a namespace named MaryTests to organize the test code
namespace MaryTests
{
    // Declare a public class named UnitTest1
    public class UnitTest1
    {
        // Declare a test method named Test1 using the Fact attribute from Xunit
        [Fact]
        public void Test1()
        {
            // Arrange: Set up any preconditions or initial state needed for the test

            // Create an instance of the Service class (Assuming Service contains the AddUp method)
            var service = new Service();

            // Act: Perform the actual operation that you want to test

            // Call the AddUp method on the service instance with arguments 3 and 4
            int result = service.AddUp(3, 4);

            // Assert: Verify that the actual result matches the expected result

            // Check that the result is equal to the expected value of 7
            Assert.Equal(7, result);
        }
    }
}
