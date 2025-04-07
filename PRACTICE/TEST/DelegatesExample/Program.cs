// MAIN
DiscountRule[] rules =                            // Instantiations
{
	new DiscountRule(Discount.None),
	new DiscountRule(Discount.Minimum),
	new DiscountRule(Discount.Average),
	new DiscountRule(Discount.Maximun),
};

//MessageFormat format = new MessageFormat(Message.Class);
MessageFormat format = Message.Class;
double buy = 100.00;
Message msg = new Message();

msg.Out(format, buy);                            // Invocation (usted compra por...)

format = new MessageFormat(msg.Instance);	

foreach (DiscountRule rule in rules)  
{
	double saving = Discount.Apply(rule, buy);      // Invocation
	msg.Out(format, saving);	                    // Invocation
}
// FIN MAIN

delegate double DiscountRule();  // reglas de descuento
delegate string MessageFormat(); // formato de los mensajes

class Message
{
	public string Instance() { return "You save {0:C}"; }                // devuelve un formato
	public static string Class() { return "You are buying for {0:C}"; }  // devuelve un formato
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