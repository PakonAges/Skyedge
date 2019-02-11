using UnityEngine;

public class FieldDataProvider : IFieldDataProvider
{
    private Field _matchField;
    public Field GameField
    {
        get
        {
            if (_matchField == null)
            {
                Debug.LogError("Someine is Trying to get FieldData, when it's not here");
            }
            return _matchField;
        }

        set { _matchField = value; }
    }

}
