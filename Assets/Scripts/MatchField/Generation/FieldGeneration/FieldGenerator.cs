using UnityEngine;

public class FieldGenerator : IFieldGenerator
{
    public Field GenerateField(FieldGenerationRules rules)
    {
        var NewField = new Field(rules.Xsize, rules.Ysize);

        for (int x = 0; x < rules.Xsize; x++)
        {
            for (int y = 0; y < rules.Ysize; y++)
            {
                NewField.FieldMatrix[x, y] = new Chip(x, y, ChipType.EmptyCell); //Chip types apropriate? or  use empty grid?
            }
        }

        //Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator", rules.Xsize, rules.Ysize, rules.ChipTypes.Count);

        return NewField;
    }

    //Create Chip at the place
    //If this is a Normal Piece - add component Moveable? Or is it easier to make it monobehavior?
}
