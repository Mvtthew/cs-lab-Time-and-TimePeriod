using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTimePeriod;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TimeTimePeriodUnitTests
{
    [TestClass]
    public class TimeUnitTests
    {

        #region Constructors

        [TestMethod, TestCategory("Constructor")]
        [DataRow((byte)0, (byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22, (byte)12)]
        [DataRow((byte)17, (byte)11, (byte)32)]
        [DataRow((byte)23, (byte)59, (byte)59)]
        public void Time_3Arguments(byte h, byte m, byte s) {
            var t = new Time(h, m, s);
            Assert.AreEqual($"{h:D2}:{m:D2}:{s:D2}", t.ToString());
        }

        [TestMethod, TestCategory("Constructor")]
        [DataRow((byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22)]
        [DataRow((byte)17, (byte)11)]
        [DataRow((byte)23, (byte)59)]
        public void Time_2Arguments(byte h, byte m) {
            var t = new Time(h, m);
            Assert.AreEqual($"{h:D2}:{m:D2}:00", t.ToString());
        }

        [TestMethod, TestCategory("Constructor")]
        [DataRow((byte)0)]
        [DataRow((byte)5)]
        [DataRow((byte)17)]
        [DataRow((byte)23)]
        public void Time_1Argument(byte h) {
            var t = new Time(h);
            Assert.AreEqual($"{h:D2}:00:00", t.ToString());
        }
        
        [TestMethod, TestCategory("Constructor")]
        [DataRow((byte)0, (byte)0, (byte)0, "0:00:00")]
        [DataRow((byte)5, (byte)22, (byte)12, "5:22:12")]
        [DataRow((byte)17, (byte)11, (byte)32, "17:11:32")]
        [DataRow((byte)23, (byte)59, (byte)59, "23:59:59")]
        public void Time_StringArgument(byte h, byte m, byte s, string timeString) {
            var t = new Time(timeString);
            Assert.AreEqual($"{h:D2}:{m:D2}:{s:D2}", t.ToString());
        }

        #endregion
        
        #region To String

        [TestMethod, TestCategory("ToString")]
        [DataRow((byte)0, (byte)0, (byte)0)]
        [DataRow((byte)14, (byte)53, (byte)11)]
        [DataRow((byte)23, (byte)17, (byte)1)]
        public void Time_ToString(byte h, byte m, byte s) {
            var t = new Time(h, m, s);
            Assert.AreEqual($"{h:D2}:{m:D2}:{s:D2}", t.ToString());
        }

		#endregion

		#region Eqatable
        
        [TestMethod, TestCategory("Eqatable")]
        [DataRow((byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22, (byte)12, (byte)5, (byte)22, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)59, (byte)59)]
        public void Time_EqatableTrue(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2) {
            var t1 = new Time(h1, m1, s1);
            var t2 = new Time(h2, m2, s2);
            Assert.AreEqual(t1, t2);
            Assert.IsTrue(t1 == t2);
            Assert.IsFalse(t1 != t2);
            Assert.IsTrue(t1.Equals(t2));
        }
        
        [TestMethod, TestCategory("Eqatable")]
        [DataRow((byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)1)]
        [DataRow((byte)5, (byte)22, (byte)12, (byte)4, (byte)22, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)22, (byte)50, (byte)19)]
        public void Time_EqatableFalse(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2) {
            var t1 = new Time(h1, m1, s1);
            var t2 = new Time(h2, m2, s2);
            Assert.AreNotEqual(t1, t2);
            Assert.IsFalse(t1 == t2);
            Assert.IsTrue(t1 != t2);
            Assert.IsFalse(t1.Equals(t2));
        }

        #endregion

        #region Comparable

        [TestMethod, TestCategory("Comparable")]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)7, (byte)22, (byte)12, (byte)6, (byte)22, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)49, (byte)59)]
        public void Time_ComparableGreaterSmaller(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            var t1 = new Time(h1, m1, s1);
            var t2 = new Time(h2, m2, s2);
            Assert.IsTrue(t1 > t2);
            Assert.IsTrue(t2 < t1);
            Assert.IsFalse(t1.Equals(t2));
        }

        [TestMethod, TestCategory("Comparable")]
        [DataRow((byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22, (byte)12, (byte)5, (byte)22, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)59, (byte)59)]
        public void Time_ComparableGreaterEqualesSmallerEquales(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            var t1 = new Time(h1, m1, s1);
            var t2 = new Time(h2, m2, s2);
            Assert.AreEqual(t1, t2);
            Assert.IsTrue(t1 >= t2);
            Assert.IsTrue(t1 <= t2);
            Assert.IsTrue(t1.Equals(t2));
        }

        #endregion
    }

    [TestClass]
    public class TimePeriodUnitTests
    {

        #region Constructors

        [TestMethod, TestCategory("Constructor")]
        [DataRow((byte)0, (byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22, (byte)12)]
        [DataRow((byte)17, (byte)11, (byte)32)]
        [DataRow((byte)23, (byte)59, (byte)59)]
        public void TimePeriod_3Arguments(byte s, byte m, byte h) {
            var t = new TimePeriod(s, m, h);
            Assert.AreEqual($"{h}:{m:D2}:{s:D2}", t.ToString());
        }

        [TestMethod, TestCategory("Constructor")]
        [DataRow((byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22)]
        [DataRow((byte)17, (byte)11)]
        [DataRow((byte)23, (byte)59)]
        public void TimePeriod_2Arguments(byte s, byte m) {
            var t = new TimePeriod(s, m);
            Assert.AreEqual($"0:{m:D2}:{s:D2}", t.ToString());
        }

        [TestMethod, TestCategory("Constructor")]
        [DataRow((byte)0)]
        [DataRow((byte)5)]
        [DataRow((byte)17)]
        [DataRow((byte)23)]
        public void TimePeriod_1Argument(byte s) {
            var t = new TimePeriod(s);
            Assert.AreEqual($"0:00:{s:D2}", t.ToString());
        }
        
        [TestMethod, TestCategory("Constructor")]
        [DataRow((byte)0, (byte)0, (byte)0, "0:00:00")]
        [DataRow((byte)5, (byte)22, (byte)12, "5:22:12")]
        [DataRow((byte)17, (byte)11, (byte)32, "17:11:32")]
        [DataRow((byte)23, (byte)59, (byte)59, "23:59:59")]
        public void TimePeriod_StringArgument(byte h, byte m, byte s, string timeString) {
            var t = new TimePeriod(timeString);
            Assert.AreEqual($"{h}:{m:D2}:{s:D2}", t.ToString());
        }

        #endregion

        #region To String

        [TestMethod, TestCategory("ToString")]
        [DataRow((byte)0, (byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22, (byte)12)]
        [DataRow((byte)17, (byte)11, (byte)32)]
        [DataRow((byte)23, (byte)59, (byte)59)]
        public void TimePeriod_ToString(byte h, byte m, byte s)
        {
            var t = new TimePeriod(s, m, h);
            Assert.AreEqual($"{h}:{m:D2}:{s:D2}", t.ToString());
        }

        #endregion

        #region Eqatable
        
        [TestMethod, TestCategory("Eqatable")]
        [DataRow((byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22, (byte)12, (byte)5, (byte)22, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)59, (byte)59)]
        public void TimePeriod_EqatableTrue(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2) {
            var t1 = new TimePeriod(h1, m1, s1);
            var t2 = new TimePeriod(h2, m2, s2);
            Assert.AreEqual(t1, t2);
            Assert.IsTrue(t1 == t2);
            Assert.IsFalse(t1 != t2);
            Assert.IsTrue(t1.Equals(t2));
        }
        
        [TestMethod, TestCategory("Eqatable")]
        [DataRow((byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)1)]
        [DataRow((byte)5, (byte)22, (byte)12, (byte)4, (byte)22, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)22, (byte)50, (byte)19)]
        public void TimePeriod_EqatableFalse(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2) {
            var t1 = new TimePeriod(h1, m1, s1);
            var t2 = new TimePeriod(h2, m2, s2);
            Assert.AreNotEqual(t1, t2);
            Assert.IsFalse(t1 == t2);
            Assert.IsTrue(t1 != t2);
            Assert.IsFalse(t1.Equals(t2));
        }

        #endregion

        #region Comparable

        [TestMethod, TestCategory("Comparable")]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)7, (byte)22, (byte)12, (byte)6, (byte)22, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)49, (byte)59)]
        public void TimePeriod_ComparableGreaterSmaller(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2) {
            var t1 = new TimePeriod(h1, m1, s1);
            var t2 = new TimePeriod(h2, m2, s2);
            Assert.IsTrue(t1 > t2);
            Assert.IsTrue(t2 < t1);
            Assert.IsFalse(t1.Equals(t2));
        }

        [TestMethod, TestCategory("Comparable")]
        [DataRow((byte)0, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)5, (byte)22, (byte)12, (byte)5, (byte)22, (byte)12)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)59, (byte)59)]
        public void TimePeriod_ComparableGreaterEqualesSmallerEquales(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2) {
            var t1 = new TimePeriod(h1, m1, s1);
            var t2 = new TimePeriod(h2, m2, s2);
            Assert.AreEqual(t1, t2);
            Assert.IsTrue(t1 >= t2);
            Assert.IsTrue(t1 <= t2);
            Assert.IsTrue(t1.Equals(t2));
        }

        #endregion
    }
}