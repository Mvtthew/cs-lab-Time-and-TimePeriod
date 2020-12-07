using System;

namespace TimeTimePeriod {
	class Program {
		static void M(string[] args) {
			var time = new Time("3:55:22");
			Console.WriteLine(time.ToString());

			var tp = new TimePeriod("2:56:20");
			Console.WriteLine(tp.ToString());

			time.Minus(tp);
			Console.WriteLine(time.ToString());
		}
	}
}
