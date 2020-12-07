using System;

namespace TimeTimePeriod {
	struct TimePeriod {
		long Period; // period in secounds

		///<Summary>
		/// Create TimePeriod object providing 3/2/1 arguments (secounds, [optional] minutes, [optional] hours)
		///</Summary>
		public TimePeriod(byte secounds, byte minutes = 0, byte hours = 0) {
			Period = secounds + minutes * 60 + hours * 60 * 60;
		}

		///<Summary>
		/// Create TimePeriod object providing string argument, format: hh:mm:ss
		///</Summary>
		public TimePeriod(string periodString) {
			var timeFromString = periodString.Split(':');
			if (timeFromString.Length != 3) {
				throw new ArgumentException();
			}
			int hours = int.Parse(timeFromString[0]);
			int minutes = int.Parse(timeFromString[1]);
			int secounds = int.Parse(timeFromString[2]);
			Period = secounds + minutes * 60 + hours * 60 * 60;
		}

		///<Summary>
		/// Cast TimePeriod object to string readable value [h:mm:ss]
		///</Summary>
		public override string ToString() {
			long hours = Period / 60 / 60;
			long minutes = Period / 60 % 60;
			long secounds =  Period % 60;
			string hString = hours.ToString();
			string mString = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
			string sString = secounds < 10 ? "0" + secounds.ToString() : secounds.ToString();
			return $"{hString}:{mString}:{sString}";
		}

		public override int GetHashCode() {
			int hash = 58;
			return Convert.ToInt32(Period) + hash;
		}
		public override bool Equals(object obj) {
			return obj.GetHashCode() == this.GetHashCode();
		}
		public static bool operator ==(TimePeriod a, TimePeriod b) {
			return a.Equals(b);
		}
		public static bool operator !=(TimePeriod a, TimePeriod b) {
			return !a.Equals(b);
		}
		public static bool operator <(TimePeriod a, TimePeriod b) {
			return a.Period < b.Period;
		}
		public static bool operator <=(TimePeriod a, TimePeriod b) {
			return a.Period <= b.Period;
		}
		public static bool operator >(TimePeriod a, TimePeriod b) {
			return a.Period > b.Period;
		}
		public static bool operator >=(TimePeriod a, TimePeriod b) {
			return a.Period >= b.Period;
		}

		public TimePeriod Plus(TimePeriod a) {
			Period += a.Period;
			return this;
		}
		public static TimePeriod Plus(TimePeriod a, TimePeriod b) {
			a.Period += b.Period;
			return a;
		}
		public TimePeriod Minus(TimePeriod a) {
			Period -= a.Period;
			return this;
		}
		public static TimePeriod Minus(TimePeriod a, TimePeriod b) {
			a.Period -= b.Period;
			return a;
		}
		public static TimePeriod operator +(TimePeriod a, TimePeriod b) {
			return a.Plus(b);
		}
		public static TimePeriod operator -(TimePeriod a, TimePeriod b) {
			return a.Minus(b);
		}
	}
}