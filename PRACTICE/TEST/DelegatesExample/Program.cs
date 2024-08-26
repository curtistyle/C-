// MAIN
DiscountRule[] rules =                            // Instantiations
{
	new DiscountRule(Discount.None),
	new DiscountRule(Discount.Minimum),
	new DiscountRule(Discount.Average),
	new DiscountRule(Discount.Maximun),
};

MessageFormat format = new MessageFormat(Message.Class);

double buy = 100.00;
Message msg = new Message();

msg.Out(format, buy);                            // Invocation

format = new MessageFormat(msg.Instance);	

foreach (DiscountRule r in rules)  
{
	double saving = Discount.Apply(r, buy);      // Invocation
	msg.Out(format, saving);	                 // Invocation
}
// FIN MAIN

delegate double DiscountRule();
delegate string MessageFormat();

class Message
{
	public string Instance() { return "You save {0:C}"; }
	public static string Class() { return "You are buying for {0:C}"; }
	public void Out (MessageFormat format, double d)
	{
		Console.WriteLine(format(), d);
	}
}

class Discount
{
	public static double Apply(DiscountRule rule, double amount)
	{
		return rule() * amount; // callback
	}
	public static double Maximun() { return 0.50; }
	public static double Average() { return 0.20; }
	public static double Minimum() { return 0.10; }
	public static double None() { return 0.00; }
}