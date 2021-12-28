using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BlazingPizza.Client
{
    public class OrderState
    {
        public bool ShowConfigureDialog { get; set; }
        public Pizza ConfiguringPizza { get; set; }
        public Order Order { get; set; } = new Order();
        
        
        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new Pizza()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>()
            };
            ShowConfigureDialog = true;
        }
    
        public void CancelConfigurePizzaDialog()
        {
            ConfiguringPizza = null;
            ShowConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            Order.Pizzas.Add(ConfiguringPizza);

            ConfiguringPizza = null;
            ShowConfigureDialog = false;
        }

        public void ResetOrder()
        {
            Order = new Order();
        }

        public void RemoveConfiguredPizza(Pizza configuredPizza)
        {
            Order.Pizzas.Remove(configuredPizza);
        }

        public void ReplaceOrder(Order order)
        {
            Order = order;
        }
    }
}