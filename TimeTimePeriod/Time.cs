using System;

namespace TimeTimePeriod {
	struct Time {
		public byte Hours;
		public byte Minutes;
		public byte Seconds;

		///<Summary>
		/// Create Time object providing 3/2/1 arguments (secounds, [optional] minutes, [optional] hours)
		///</Summary>
		public Time(byte hours, byte minutes = 0, byte secounds = 0) {
			Hours = (byte)(hours % 24);
			Minutes = (byte)(minutes % 60);
			Seconds = (byte)(secounds % 60);
		}

		///<Summary>
		/// Create Time object providing string argument, format: hh:mm:ss
		///</Summary>
		public Time(string timeString) {
			var timeFromString = timeString.Split(':');
			if (timeFromString.Length != 3) {
				throw new ArgumentException();
			}
			Hours = Byte.Parse(timeFromString[0]);
			Minutes = Byte.Parse(timeFromString[1]);
			Seconds = Byte.Parse(timeFromString[2]);
		}

		///<Summary>
		/// Cast Time object to string readable value [hh:mm:ss]
		///</Summary>
		public override string ToString() {
			string hString = Hours < 10 ? "0" + Hours.ToString() : Hours.ToString();
			string mString = Minutes < 10 ? "0" + Minutes.ToString() : Minutes.ToString();
			string sString = Seconds < 10 ? "0" + Seconds.ToString() : Seconds.ToString();
			return $"{hString}:{mString}:{sString}";
		}

		public override int GetHashCode() {
			int hash = 58;
			return int.Parse($"{Hours}{Minutes}{Seconds}") + hash;
		}
		public override bool Equals(object obj) {
			return obj.GetHashCode() == this.GetHashCode();
		}
		public static bool operator ==(Time a, Time b) {
			return a.Equals(b);
		}
		public static bool operator !=(Time a, Time b) {
			return !a.Equals(b);
		}
		public static bool operator <(Time a, Time b) {
			if (a.Hours < b.Hours) {
				return true;
			} else if (a.Hours == b.Hours) {
				if (a.Minutes < b.Minutes) {
					return true;
				} else if (a.Minutes == b.Minutes) {
					if (a.Seconds < b.Seconds) {
						return true;
					} else {
						return false;
					}
				} else {
					return false;
				}
			} else {
				return false;
			}
		}
		public static bool operator <=(Time a, Time b) {
			if (a.Equals(b)) return true;
			if (a.Hours < b.Hours) {
				return true;
			} else if (a.Hours == b.Hours) {
				if (a.Minutes < b.Minutes) {
					return true;
				} else if (a.Minutes == b.Minutes) {
					if (a.Seconds < b.Seconds) {
						return true;
					} else {
						return false;
					}
				} else {
					return false;
				}
			} else {
				return false;
			}
		}
		public static bool operator >(Time a, Time b) {
			if (a.Hours < b.Hours) {
				return false;
			} else if (a.Hours == b.Hours) {
				if (a.Minutes < b.Minutes) {
					return false;
				} else if (a.Minutes == b.Minutes) {
					if (a.Seconds < b.Seconds) {
						return false;
					} else {
						return true;
					}
				} else {
					return true;
				}
			} else {
				return true;
			}
		}
		public static bool operator >=(Time a, Time b) {
			if (a.Equals(b)) return true;
			if (a.Hours < b.Hours) {
				return false;
			} else if (a.Hours == b.Hours) {
				if (a.Minutes < b.Minutes) {
					return false;
				} else if (a.Minutes == b.Minutes) {
					if (a.Seconds < b.Seconds) {
						return false;
					} else {
						return true;
					}
				} else {
					return true;
				}
			} else {
				return true;
			}
		}

		public Time Plus(TimePeriod a) {
			TimePeriod n = new TimePeriod(this.Seconds, this.Minutes, this.Hours);
			n.Plus(a);
			string periodString = n.ToString();
			var splittedPeriod = periodString.Split(":");
			string hString = splittedPeriod[0];
			string mString = splittedPeriod[1];
			string sString = splittedPeriod[2];
			Hours = byte.Parse(hString);
			Minutes = byte.Parse(mString);
			Seconds = byte.Parse(sString);
			return new Time(n.ToString());
		}
		public static Time Plus(Time a, TimePeriod b) {
			return a.Plus(b);
		}
		public Time Minus(TimePeriod a) {
			TimePeriod n = new TimePeriod(this.Seconds, this.Minutes, this.Hours);
			n.Minus(a);
			string periodString = n.ToString();
			var splittedPeriod = periodString.Split(":");
			string hString = splittedPeriod[0];
			string mString = splittedPeriod[1];
			string sString = splittedPeriod[2];
			Hours = byte.Parse(hString);
			Minutes = byte.Parse(mString);
			Seconds = byte.Parse(sString);
			return new Time(n.ToString());
		}
		public static Time Minus(Time a, TimePeriod b) {
			return a.Minus(b);
		}
		public static Time operator +(Time a, TimePeriod b) {
			return a.Plus(b);
		}
		public static Time operator -(Time a, TimePeriod b) {
			return a.Minus(b);
		}
	}

	public interface IEquatable<Time, TimePeriod> { }

	public interface IComparable<Time, TimePeriod> { }
}