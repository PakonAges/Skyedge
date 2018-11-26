public class FieldDataProvider : IFieldDataProvider
{
    FieldData _defaultRules;

    //public FieldDataProvider(FieldData nullRules)
    //{
    //    _defaultRules = nullRules;
    //}

    public FieldData ProvideData()
    {
        //Rules definition logic
        var Data = new FieldData(8, 8, 5);
        return Data;

        //if (rules != null)
        //{
        //    return rules;
        //}
        //else
        //{
        //    return _defaultRules;
        //}
    }
}
