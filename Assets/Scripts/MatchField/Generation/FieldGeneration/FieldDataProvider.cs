using UnityEngine;

public class FieldDataProvider : IFieldDataProvider
{
    Field _defaultRules;
    Sprite _defaultFieldBG;

    public FieldDataProvider (Sprite defaultFieldBg)
    {
        _defaultFieldBG = defaultFieldBg;
    }

    public Sprite ProvideBGData()
    {
        return _defaultFieldBG;
    }

    //public FieldDataProvider(FieldData nullRules)
    //{
    //    _defaultRules = nullRules;
    //}

    public Field ProvideData()
    {
        //Rules definition logic
        var Data = new Field(8, 8, 5);
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
