using System.Collections.Generic;

using Models;

namespace ServiceLayer.LinqExtentions
{
    public static class LinqExtentions
    {
        /// <summary>
        /// Returns the total order sum
        /// </summary>
        /// <param name="orderDetails">order details</param>
        /// <returns>decimal</returns>
        public static decimal GetOrdersSum(this ICollection<Order_Detail> orderDetails)
        {
            decimal totalSum = 0M;

            foreach (var orderDetail in orderDetails)
            {
                decimal currentSum = orderDetail.Quantity * orderDetail.UnitPrice;

                if (orderDetail.Discount > 0)
                {
                    currentSum = currentSum - (currentSum * (decimal)orderDetail.Discount);
                }

                totalSum += currentSum;
            }

            return totalSum;
        }

        /// <summary>
        /// Returns the total order sum with freight cost if there is a freight cost
        /// </summary>
        /// <param name="orderDetails">order details</param>
        /// <param name="freightCost">freight cost</param>
        /// <returns>decimal</returns>
        public static decimal GetOrdersSumWithFreight(this ICollection<Order_Detail> orderDetails, decimal? freightCost)
        {
            decimal orderSum = orderDetails.GetOrdersSum();

            if (ThereIsNoFreightCost(freightCost))
            {
                return orderSum;
            }

            return orderSum + (decimal)freightCost;
        }

        /// <summary>
        /// Checks if the freightCost is null or 0
        /// </summary>
        /// <param name="freightCost">FreightCost</param>
        /// <returns>bool</returns>
        private static bool ThereIsNoFreightCost(decimal? freightCost)
        {
            return freightCost == null || freightCost == 0;
        }
    }
}