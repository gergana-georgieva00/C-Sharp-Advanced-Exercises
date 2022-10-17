using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAdress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAdress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get { return this.Portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.Any(c => c.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }

            Stock stockToSell = this.Portfolio.Where(c => c.CompanyName == companyName).ToList()[0];
            if (stockToSell.PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }

            this.Portfolio = this.Portfolio.Where(c => c.CompanyName != companyName).ToList();
            this.MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            if (this.Portfolio.Any(s => s.CompanyName == companyName))
            {
                Stock stock = this.Portfolio.Where(s => s.CompanyName == companyName).ToList()[0];
                return stock;
            }

            return null;
        }

        public Stock FindBiggestCompany()
        {
            if (this.Portfolio.Count > 0)
            {
                Stock stock = this.Portfolio.OrderByDescending(s => s.MarketCapitalization).ToList()[0];
                return stock;
            }

            return null;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            for (int i = 0; i < this.Portfolio.Count; i++)
            {
                if (i == this.Portfolio.Count - 1)
                {
                    sb.Append(this.Portfolio[i].ToString());
                }
                else
                {
                    sb.AppendLine(this.Portfolio[i].ToString());
                }
            }

            return sb.ToString();
        }
    }
}
