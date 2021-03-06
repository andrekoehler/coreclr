using System;
/// <summary>
/// Remainder(System.Decimal,System.Decimal)
/// </summary>
public class DecimalRemainder
{
    #region Public Methods
    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negtive]");
        retVal = NegTest1() && retVal;
        return retVal;
    }

    #region Positive Test Cases
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: check Two Decimal Remainder.");

        try
        {
            
            Decimal m2 = 7m;
            Decimal expectValue = m2-1m;
            Decimal m1 = m2 * 1000 + expectValue;
          
            Decimal actualValue = Decimal.Remainder(m1,m2);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.1", "Remainder should  return " + expectValue);
                retVal = false;
            }
          
            m1 = m2 * (-1000) - expectValue;
            actualValue = Decimal.Remainder(m1, m2);
            if (actualValue != -expectValue)
            {
                TestLibrary.TestFramework.LogError("001.2", "Remainder should  return " + expectValue);
                retVal = false;
            }


            m1 = 123.0000000m;
            m2 = 0.0012300m;
            expectValue = 0m;
            actualValue = Decimal.Remainder(m1, m2);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.3", "Remainder should  return " + expectValue);
                retVal = false;
            }


            m1 = 12345678900000000m;
            m2 = 0.0000000012345678m;
            expectValue = 0.000000000983m;
            actualValue = Decimal.Remainder(m1, m2);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.4", "Remainder should  return " + expectValue);
                retVal = false;
            }


            m1 = 123456789.0123456789m;
            m2 = 123456789.0123456789m;
            expectValue = 0;
            actualValue = Decimal.Remainder(m1, m2);
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.5", "Remainder should  return " + expectValue);
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    #endregion
    #region NegiTive Test
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1: d2 is zero.");

        try
        {
            Decimal m1 = Decimal.MaxValue;
            Decimal m2 = 0;
            Decimal actualValue = Decimal.Remainder(m1, m2);
            TestLibrary.TestFramework.LogError("101.1", "DivideByZeroException should be caught.");
            retVal = false;
        }
        catch (DivideByZeroException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
  
    #endregion
    #endregion

    public static int Main()
    {
        DecimalRemainder test = new DecimalRemainder();

        TestLibrary.TestFramework.BeginTestCase("DecimalRemainder");

        if (test.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    #region private method
    public TypeCode GetExpectValue(Decimal myValue)
    {
        return TypeCode.Decimal;
    }
    #endregion
}
