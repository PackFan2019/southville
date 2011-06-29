namespace StudentAssessment.Objects
{
    public enum ItemType
    {
        Service = 5,
        Kit = 3
    }

    #region Discount Enums
    public enum Discount_Type
    {
        Fixed_Discount = 0,
        Variable_Discount = 1,
        Special = -1
    }
    #endregion 

    #region Transaction Enums

    public enum Transaction_Type : short
    {
        Assessment = 1,
        Add = 3,
        Drop = 4
    }

    public static class Constants
    {
        public const string SUBTOTAL = "Subtotal";
        public const string TUITIONFEES = "Tuition Fees";
        public const string MISCELLANEOUSFEES = "Miscellaneous Fees";
        public const string DIRECTCOSTS = "Direct Costs";
        public const string ADDITIONALFEES = "Additional Fees";
    }

    #endregion
}