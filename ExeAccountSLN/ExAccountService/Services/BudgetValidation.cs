namespace ExAccountService.Services
{
    public class BudgetValidationService
    {
        public List<Itens> getMaximumSpend(int[] listOne, int[] listTwo, int budget)
        {
            //Here we Have the validations of minimum requirements
            if (listOne.Count() > 100 || listTwo.Count() > 100)
                throw new Exception("List cannot be more than 100 intens!");

            if (listOne.Count() == 0 || listTwo.Count() == 0)
                throw new Exception("List cannot empty!");

            if (budget <= 0)
                throw new Exception("Budget is not enough to proceed!");

            var possible1 = listOne.Where(x => x < budget);
            var possible2 = listTwo.Where(x => x < budget);

            if (possible1.Count() == 0 || possible2.Count() == 0)
                throw new Exception("-1");

            //Here we Have Logical to verify and set the possible options.
            List<Itens> list = new List<Itens>();

            foreach (var possible in possible1)
            {
                foreach (var insedePossible in possible2)
                {
                    if (possible + insedePossible <= budget)
                        list.Add(new Itens
                        {
                            ValueIten1 = possible,
                            ValueIten2 = insedePossible
                        });
                }
            }

            //Here we Have validation if it was possible to buy any item.
            if (list.Count() == 0)
                throw new Exception("-1");

            return list;
        }
    }
    public struct Itens
    {
        public int ValueIten1 { get; set; }
        public int ValueIten2 { get; set; }
    }
}