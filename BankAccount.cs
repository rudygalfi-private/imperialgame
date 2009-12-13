namespace Imperial
{
    class BankAccount
    {
        private uint balance;

        public uint Balance
        {
            get
            {
                return balance;
            }
        }

        public void ZeroBalance()
        {
            this.balance = 0;
        }

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

        public uint WithdrawMoney(uint withdrawalMoney, bool forceWithdrawal)
        {
            if (HasSufficientFunds(withdrawalMoney))
            {
                this.balance -= withdrawalMoney;
                return 0;
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

        public bool HasSufficientFunds(uint amount)
        {
            return amount <= this.balance;
        }

        public uint TransferMoneyToBankAccount(uint amount, BankAccount destination, bool forceTransfer)
        {
            uint amountWithdrawn = this.WithdrawMoney(amount, forceTransfer);
            destination.DepositMoney(amountWithdrawn);
            return amountWithdrawn;
        }

        public uint TransferMoneyFromBankAccount(uint amount, BankAccount source, bool forceTransfer)
        {
            return source.TransferMoneyToBankAccount(amount, this, forceTransfer);
        }
    }
}
