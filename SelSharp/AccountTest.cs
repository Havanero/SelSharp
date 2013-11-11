using System;

namespace SelSharp
{
	 using NUnit.Framework;

  [TestFixture]
  public class AccountTest
  {
    [Test]
    public void TransferFunds()
    {
      Account source = new Account();
      source.Deposit(200m);
      
      Account destination = new Account();
      destination.Deposit(150m);

      source.TransferFunds(destination, 100m);
	  
      Assert.AreEqual(250m, destination.Balance);
      Assert.AreEqual(100m, source.Balance);
    }

	
		[Test]
		[ExpectedException(typeof(InsufficientFundsException))]
	
		public void TransferWithInsufficientFunds(){
  		Account source = new Account();
  		source.Deposit(200m);
	
  		Account destination = new Account();
  		destination.Deposit(150m);
	
  		source.TransferFunds(destination, 300m);
		}

		[Test]
		[Ignore("Decide how to implement transaction management")]

		public void TransferWithInsufficientFundsAtomicity()

		{
  		Account source = new Account();
  		source.Deposit(200m);

  		Account destination = new Account();
  		destination.Deposit(150m);
	
  		try
  		{
  		source.TransferFunds(destination, 300m);
  		}	
  		catch(InsufficientFundsException expected)
  		{
  		}

  		Assert.AreEqual(200m, source.Balance);
  		Assert.AreEqual(150m, destination.Balance);
		}
  }
}

