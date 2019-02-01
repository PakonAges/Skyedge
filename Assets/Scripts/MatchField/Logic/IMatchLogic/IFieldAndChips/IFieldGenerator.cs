using System.Threading.Tasks;

public interface IFieldGenerator {

    Task<Field> GenerateFieldAsync(FieldGenerationRules fieldGenerationRules);
}