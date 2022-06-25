namespace GenericRepositoryExample.Extensions
{
    public static class ReflectionExtension
    {
        public static string GetColumnValue(this Object model, string columnName)
        {
            return model.GetType().GetProperty(columnName).GetValue(model, null).ToString();
        }
    }
}
