// <copyright file="BankAccount.cs" company="Untitled">
//     Copyright (c) Untitled. All rights reserved.
// </copyright>

namespace Imperial
{
    /// <summary>
    /// Implements a bank account.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// The balance of the bank account.
        /// </summary>
        private uint balance;

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
        /// <param name="depositMoney">The amount to deposit.</param>
        public void DepositMoney(uint depositMoney)
        {
            try
            {
                this.balance += depositMoney;
            }
            catch (System.OverflowException e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <param name="withdrawalMoney">The amount to withdraw.</param>
        /// <param name="forceWithdrawal">Whether to force the withdrawl even if there are insufficient funds.</param>
        /// <returns>The actual amount withdrawn from the account even if there were insufficient funds.</returns>
        public uint WithdrawMoney(uint withdrawalMoney, bool forceWithdrawal)
        {
            if (this.HasSufficientFunds(withdrawalMoney))
            {
                this.balance -= withdrawalMoney;
                return withdrawalMoney;
            }
            else
            {
                if (forceWithdrawal)
                {
                    uint withdrawnMoney = this.balance;
                    this.ZeroBalance();
                    return withdrawnMoney;
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
        /// <param name="forceTransfer">Whether to force the transfer even if there are insufficient funds in this account.</param>
        /// <returns>The actual amount transferred even if there were insufficient funds.</returns>
        public uint TransferMoneyToBankAccount(uint amount, BankAccount destination, bool forceTransfer)
        {
            uint amountWithdrawn = this.WithdrawMoney(amount, forceTransfer);
            destination.DepositMoney(amountWithdrawn);
            return amountWithdrawn;
        }

        /// <summary>
        /// Transfers money from the specified source account to this account.
        /// </summary>
        /// <param name="amount">The amount to transfer.</param>
        /// <param name="source">The source account.</param>
        /// <param name="forceTransfer">Whether to force the transfer even if there are insufficient funds in the source account.</param>
        /// <returns>The actual amount transferred even if there were insufficient funds.</returns>
        public uint TransferMoneyFromBankAccount(uint amount, BankAccount source, bool forceTransfer)
        {
            return source.TransferMoneyToBankAccount(amount, this, forceTransfer);
        }
    }
}
