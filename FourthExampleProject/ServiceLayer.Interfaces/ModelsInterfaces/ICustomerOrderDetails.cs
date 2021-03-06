﻿namespace ServiceLayer.Interfaces.ModelsInterfaces
{
    public interface ICustomerOrderDetails
    {
        decimal OrderSum { get; set; }

        decimal OrderSumWithFreight { get; set; }

        int ProductsCount { get; set; }

        bool PossibleProblem { get; set; }
    }
}