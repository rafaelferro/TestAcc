using ExAccountService.Services;

namespace ExAccountTest
{
    public class BudgetValidationTest
    {
        private BudgetValidationService budget;

        public BudgetValidationTest()
        {
            budget = new BudgetValidationService();
        }

        [Fact]
        public void SholdBeSuccesswith6()
        {
            int[] ListOne = new int[] { 1, 2, 3, 9 };
            int[] ListTwo = new int[] { 3, 5, 6, 8, 4 };

            var result = budget.getMaximumSpend(ListOne, ListTwo, 6);
            var ResultList = new List<int>();
            foreach (var res in result)
            {
                if (res.ValueIten1 + res.ValueIten2 > 6)
                    ResultList.Add(res.ValueIten1 + res.ValueIten2);
            }

            Assert.Empty(ResultList);
        }

        [Fact]
        public void SholdBeSuccesswith19()
        {
            int[] ListOne = new int[] { 1, 2, 3, 9 };
            int[] ListTwo = new int[] { 3, 5, 6, 8, 4 };

            var result = budget.getMaximumSpend(ListOne, ListTwo, 19);
            var ResultList = new List<int>();
            foreach (var res in result)
            {
                if (res.ValueIten1 + res.ValueIten2 > 19)
                    ResultList.Add(res.ValueIten1 + res.ValueIten2);
            }

            Assert.Empty(ResultList);
        }

        [Fact]
        public void SholdBeErrorMoreThan100Itens()
        {
            List<int> ListOne = new List<int> { 1, 2, 3, 9 };
            List<int> ListTwo = new List<int> { 3, 5, 6, 8, 4 };

            int a = 10;
            while (ListOne.Count() <= 100)
            {
                ListOne.Add(a);
                a++;
            }
            try
            {
                var result = budget.getMaximumSpend(ListOne.ToArray(), ListTwo.ToArray(), 6);
                var ResultList = new List<int>();
                Assert.Empty(result);
            }
            catch (Exception e)
            {
                Assert.Contains("List cannot be more than 100 intens!", e.Message);
            }
        }

        [Fact]
        public void SholdBeError0Itens()
        {
            List<int> ListOne = new List<int> { };
            List<int> ListTwo = new List<int> { 3, 5, 6, 8, 4 };

            try
            {
                var result = budget.getMaximumSpend(ListOne.ToArray(), ListTwo.ToArray(), 6);
                var ResultList = new List<int>();
                Assert.Empty(result);
            }
            catch (Exception e)
            {
                Assert.Contains("List cannot empty!", e.Message);
            }
        }

        [Fact]
        public void SholdBeErrorBudgetIsNotEnoughToProceed()
        {
            List<int> ListOne = new List<int> { 1, 2, 3, 9 };
            List<int> ListTwo = new List<int> { 3, 5, 6, 8, 4 };

            try
            {
                var result = budget.getMaximumSpend(ListOne.ToArray(), ListTwo.ToArray(), 0);
                var ResultList = new List<int>();
                Assert.Empty(result);
            }
            catch (Exception e)
            {
                Assert.Contains("Budget is not enough to proceed!", e.Message);
            }
        }

        [Fact]
        public void SholdBeErrorBudgetIsNotEnough()
        {
            List<int> ListOne = new List<int> { 1, 2, 3, 9 };
            List<int> ListTwo = new List<int> { 3, 5, 6, 8, 4 };

            try
            {
                var result = budget.getMaximumSpend(ListOne.ToArray(), ListTwo.ToArray(), 3);
                var ResultList = new List<int>();
                Assert.Empty(result);
            }
            catch (Exception e)
            {
                Assert.Contains("-1", e.Message);
            }
        }
    }
}