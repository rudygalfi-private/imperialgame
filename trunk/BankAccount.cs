// <copyright file="BankAccount.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Defines and implements a BankAccount.
    /// </summary>
    /// <remarks>
    ///     <para>The "Bank" has infinite money, hence this class does not show the Bank's side of
    ///     transactions. In other words, non-zero-sum transactions such as Deposit and Withdraw
    ///     take place with the Bank as the other party, while zero-sum transactions such as
    ///     Transfer take place with some other BankAccount as the other party.</para>
    ///     <para>The Bank must always be fully paid.</para>
    /// </remarks>
    public sealed class BankAccount
    {
        /// <summary>
        /// The balance of the bank account.
        /// </summary>
        private uint balance = 0;

        /// <summary>
        /// Initializes a new instance of the BankAccount class with zero balance.
        /// </summary>
        public BankAccount() : this(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BankAccount class with the specified initial balance.
        /// </summary>
        /// <param name="balance">The initial balance of the BankAccount.</param>
        public BankAccount(uint balance)
        {
            this.balance = balance;
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        public uint Balance
        {
            get
            {
                return this.balance;
            }
        }

        /// <summary>
        /// Sets the balance to zero.
        /// </summary>
        public void ZeroBalance()
        {
            this.balance = 0;
        }

        /// <summary>
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <param name="depositAmount">The amount to deposit.</param>
        /// <returns>The amount deposited.</returns>
        /// <exception cref="System.ArithmeticException">Throws an exception if the amount deposited causes the account balance to overflow.</exception>
        public uint Deposit(uint depositAmount)
        {
            try
            {
                return this.balance += depositAmount;
            }
            catch (System.ArithmeticException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <param name="withdrawalRequestAmount">The amount to withdraw.</param>
        /// <param name="withdrawAsMuchAsPossible">Whether to withdraw the remaining funds even if they are less than the original withdrawl amount.</param>
        /// <returns>The actual amount withdrawn from the account even if there were insufficient funds.</returns>
        /// <remarks>
        /// When forceWidthdrawl is false, the amount withdrawn will either be the amount requested or zero;
        /// otherwise, the amount will be the remaining balance.
        /// </remarks>
        public uint Withdraw(uint withdrawalRequestAmount, bool withdrawAsMuchAsPossible)
        {
            if (this.HasSufficientFunds(withdrawalRequestAmount))
            {
                return this.Withdraw(withdrawalRequestAmount);
            }
            else
            {
                if (withdrawAsMuchAsPossible)
                {
                    return this.WithdrawRemaining();
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Checks whether the account has the specified amount of funds.
        /// </summary>
        /// <param name="amount">The amount of funds to ensure that the account has.</param>
        /// <returns>Whether the account has a balance of at least the specified amount.</returns>
        public bool HasSufficientFunds(uint amount)
        {
            return amount <= this.balance;
        }

        /// <summary>
        /// Transfers money from this account to the specified destination account.
        /// </summary>
        /// <param name="amount">The amount to transfer.</param>
        /// <param name="destination">The destination account.</param>
        /// <param name="withdrawAsMuchAsPossible">Whether to transfer the remaining funds even if they are less than the original transfer amount.</param>
        /// <returns>The actual amount transferred even if there were insufficient funds.</returns>
        public uint TransferMoneyToBankAccount(uint amount, BankAccount destination, bool withdrawAsMuchAsPossible)
        {
            uint amountWithdrawn = this.Withdraw(amount, withdrawAsMuchAsPossible);
            destination.Deposit(amountWithdrawn);
            return amountWithdrawn;
        }

        /// <summary>
        /// Transfers money from the specified source account to this account.
        /// </summary>
        /// <param name="amount">The amount to transfer.</param>
        /// <param name="source">The source account.</param>
        /// <param name="withdrawAsMuchAsPossible">Whether to transfer the remaining funds even if they are less than the original transfer amount.</param>
        /// <returns>The actual amount transferred even if there were insufficient funds.</returns>
        public uint TransferMoneyFromBankAccount(uint amount, BankAccount source, bool withdrawAsMuchAsPossible)
        {
            return source.TransferMoneyToBankAccount(amount, this, withdrawAsMuchAsPossible);
        }

        /// <summary>
        /// Withdraws the specified amount from this BankAccount.
        /// </summary>
        /// <param name="withdrawalAmount">The amount to withdraw.</param>
        /// <returns>The amount withdrawn.</returns>
        private uint Withdraw(uint withdrawalAmount)
        {
            try
            {
                return this.balance -= withdrawalAmount;
            }
            catch (System.ArithmeticException e)
            {
                System.Console.WriteLine(e.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Withdraws the remaining money from this account.
        /// </summary>
        /// <returns>The amount withdrawn.</returns>
        private uint WithdrawRemaining()
        {
            uint withdrawalAmount = this.balance;
            this.ZeroBalance();
            return withdrawalAmount;
        }
    }
}
