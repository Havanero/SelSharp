using System;

namespace SelSharp
{
	 public class Account
  {
    private decimal balance;
	
    public void Deposit(decimal amount)
    {
      balance += amount;
    }

    public void Withdraw(decimal amount)
    {
      balance -= amount;
    }

    public void TransferFunds(Account destination, decimal amount)
    {
	   destination.Deposit(amount);
	
  		if(balance-amount < minimumBalance)
    	throw new InsufficientFundsException();
		
  		Withdraw(amount);
    }

    public decimal Balance
    {
      get { return balance; }
    }
	
	private decimal minimumBalance = 10m;

	public decimal MinimumBalance
	{
 	 get{ return minimumBalance; }
	}
  }
}

