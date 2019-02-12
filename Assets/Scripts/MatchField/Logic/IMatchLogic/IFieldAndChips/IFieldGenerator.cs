using System.Threading.Tasks;

public interface IFieldGenerator {

    Task<Field> GenerateAndShowFieldAsync(FieldGenerationRules fieldGenerationRules);
}